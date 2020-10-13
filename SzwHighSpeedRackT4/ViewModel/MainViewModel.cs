using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SzwHighSpeedRackT4
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 选择文件加命令
        /// </summary>
        public RelayCommand SelectedFileTaskCommand { get; set; }

        /// <summary>
        //  生成代码
        /// </summary>
        public RelayCommand GenerateCodeTaskCommand { get; set; }

        public RelayCommand ConnectTaskCommand { get; set; }
        public RelayCommand CheckAllTaskCommand { get; set; }

        private BaseSqlHelper BaseSqlHelper { get; set; }

        public MainViewModel()
        {
            // 命令不能为私有属性否则调用出错
            SelectedFileTaskCommand = new RelayCommand(SelectedFileTask);
            GenerateCodeTaskCommand = new RelayCommand(GenerateCodeTask);
            ConnectTaskCommand = new RelayCommand(ConnectTask);
            CheckAllTaskCommand = new RelayCommand(CheckAllTask);

            InitData();
        }

        /// <summary>
        /// 全选
        /// </summary>
        private void CheckAllTask()
        {
            if (ListBoxModel != null && ListBoxModel.Count > 0)
            {
                ListBoxModel.ToList().ForEach(o =>
                {
                    o.IsCheck = isCheck;
                });
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        private void ConnectTask()
        {
            try
            {
                ListBoxModel = new ObservableCollection<ListBoxModel>();
                DataTable dt = new DataTable();
                if (keyValueModel.Key == (int)DbEnum.DbType.MySql)
                {
                    string dataBase = string.Empty;
                    string[] dataBases = connStr.Split(';');
                    foreach (var item in dataBases)
                    {
                        if (item.ToUpper().Contains("Database".ToUpper()))
                        {
                            dataBase = item.Split('=')[1];
                        }
                    }
                    string selectTable = BaseSqlHelper.SelectTableName.Replace("@Database", dataBase);
                    dt = BaseSqlHelper.ExecuteDataTable(connStr, selectTable, null);
                }
                else
                {
                    dt = BaseSqlHelper.ExecuteDataTable(connStr, BaseSqlHelper.SelectTableName, null);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string name = item["Name"].ToString();
                        if (!name.ToUpper().StartsWith("__EFMigrations".ToUpper()))
                        {
                            ListBoxModel.Add(new ListBoxModel
                            {
                                IsCheck = false,
                                TableName = name
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show("连接数据库失败！错误信息：" + ex.Message, "错误");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("不是有效的连接字符串！错误信息：" + ex.Message, "错误");
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            foreach (var item in Enum.GetValues(typeof(DbEnum.DbType)))
            {
                dbList.Add(new KeyValue
                {
                    Key = (int)item,
                    Value = item.ToString()
                });
            }

            //默认选择中第一行
            keyValueModel = dbList[1];

            //读取链接字符串
            connStr = ToolsEx.ConfigValue("ConnStr");

            InitBaseSqlHelper();
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        private void GenerateCodeTask()
        {
            if (string.IsNullOrWhiteSpace(selectFilePath))
            {
                System.Windows.MessageBox.Show("请选择代码生成路径", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<ListBoxModel> listBoxModels = listBoxModel.Where(w => w.IsCheck == true).ToList();
            if (listBoxModels == null || listBoxModels.Count <= 0)
            {
                System.Windows.MessageBox.Show("没有可生成的表实体", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Task.Factory.StartNew(() =>
            {
                listBoxModels.ForEach(o =>
                {
                    DataTable dtTable = BaseSqlHelper.ExecuteDataTable(connStr, BaseSqlHelper.SelectTableColumName.Replace("@TableName", o.TableName));
                    TemplateModel templateModel = new TemplateModel(dtTable);
                    string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Template");
                    CreateCode.CreatT4Class(templateModel, selectFilePath, path);
                });
            });
            System.Windows.MessageBox.Show("生成成功", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        ///
        /// </summary>
        private void InitBaseSqlHelper()
        {
            string className = $"SzwHighSpeedRackT4.{keyValueModel.Value}Helper";
            BaseSqlHelper = Activator.CreateInstance(Type.GetType(className)) as BaseSqlHelper;
        }

        /// <summary>
        /// 选择代码生成的路径
        /// </summary>
        public void SelectedFileTask()
        {
            FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectFilePath = System.IO.Path.Combine(folderBrowser.SelectedPath);
            }
        }

        private string connStr;

        public string ConnStr
        {
            get { return connStr; }
            set
            {
                connStr = value;
                RaisePropertyChanged();
            }
        }

        private string selectFilePath;

        public string SelectFilePath
        {
            get { return selectFilePath; }
            set
            {
                selectFilePath = value;
                RaisePropertyChanged();
            }
        }

        private bool isCheck;

        public bool IsCheck
        {
            get { return isCheck; }
            set
            {
                isCheck = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<KeyValue> dbList = new ObservableCollection<KeyValue>();

        public ObservableCollection<KeyValue> DbList
        {
            get { return dbList; }
            set
            {
                dbList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ListBoxModel> listBoxModel = new ObservableCollection<ListBoxModel>();

        public ObservableCollection<ListBoxModel> ListBoxModel
        {
            get { return listBoxModel; }
            set
            {
                listBoxModel = value;
                RaisePropertyChanged();
            }
        }

        private KeyValue keyValueModel = new KeyValue();

        /// <summary>
        /// 切换下拉框
        /// </summary>
        public KeyValue KeyValueModel
        {
            get
            {
                return keyValueModel;
            }
            set
            {
                keyValueModel = value;
                InitBaseSqlHelper();
                RaisePropertyChanged();
            }
        }
    }
}
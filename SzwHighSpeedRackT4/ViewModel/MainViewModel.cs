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

        private string BaseDirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory;

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
                //每一次点击连接,清空listbox
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

            //默认选择中第二行
            keyValueModel = dbList[1];

            //读取链接字符串
            connStr = ToolsEx.ConfigValue("ConnStr");

            InitBaseSqlHelper();

            //初始化模板下拉框数据
            InitTemplate();
        }

        private void InitTemplate()
        {
            DirectoryInfo folder = new DirectoryInfo(BaseDirectoryPath);
            List<DirectoryInfo> listDic = folder.GetDirectories().Where(w => w.Name.ToUpper().Contains("Template".ToUpper())).ToList();
            if (listDic.Count > 0)
            {
                foreach (var item in listDic)
                {
                    TemplateList.Add(new KeyValue
                    {
                        Value = item.Name
                    });
                }

                TemplateInfo = TemplateList[0];

                ChangeTemplate();
            }
        }

        private void ChangeTemplate()
        {
            ListBoxModelTemplate = new ObservableCollection<ListBoxModel>();
            string templatePath = Path.Combine(BaseDirectoryPath, TemplateInfo.Value);
            DirectoryInfo templateFile = new DirectoryInfo(templatePath);
            List<FileInfo> fileList = templateFile.GetFiles("*.tt").ToList();
            if (fileList != null && fileList.Count > 0)
            {
                foreach (var item in fileList)
                {
                    ListBoxModelTemplate.Add(new ListBoxModel
                    {
                        IsCheck = true,
                        TableName = item.Name
                    });
                }
            }
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

                    string path = Path.Combine(BaseDirectoryPath, TemplateInfo.Value);
                    CreateCode.CreatT4Class(templateModel, selectFilePath, path, ListBoxModelTemplate.Where(w => w.IsCheck == true).ToList());
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
        /// 切换数据库类型下拉框
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

        private ObservableCollection<KeyValue> templateList = new ObservableCollection<KeyValue>();

        public ObservableCollection<KeyValue> TemplateList
        {
            get { return templateList; }
            set
            {
                templateList = value;
                RaisePropertyChanged();
            }
        }

        private KeyValue templateInfo = new KeyValue();

        /// <summary>
        /// 切换模板下拉框
        /// </summary>
        public KeyValue TemplateInfo
        {
            get
            {
                return templateInfo;
            }
            set
            {
                templateInfo = value;
                ChangeTemplate();
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ListBoxModel> listBoxModelTemplate = new ObservableCollection<ListBoxModel>();

        public ObservableCollection<ListBoxModel> ListBoxModelTemplate
        {
            get { return listBoxModelTemplate; }
            set
            {
                listBoxModelTemplate = value;
                RaisePropertyChanged();
            }
        }
    }
}
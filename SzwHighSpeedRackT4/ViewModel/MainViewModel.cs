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
        /// ѡ���ļ�������
        /// </summary>
        public RelayCommand SelectedFileTaskCommand { get; set; }

        /// <summary>
        //  ���ɴ���
        /// </summary>
        public RelayCommand GenerateCodeTaskCommand { get; set; }

        public RelayCommand ConnectTaskCommand { get; set; }
        public RelayCommand CheckAllTaskCommand { get; set; }

        private BaseSqlHelper BaseSqlHelper { get; set; }

        public MainViewModel()
        {
            // �����Ϊ˽�����Է�����ó���
            SelectedFileTaskCommand = new RelayCommand(SelectedFileTask);
            GenerateCodeTaskCommand = new RelayCommand(GenerateCodeTask);
            ConnectTaskCommand = new RelayCommand(ConnectTask);
            CheckAllTaskCommand = new RelayCommand(CheckAllTask);

            InitData();
        }

        /// <summary>
        /// ȫѡ
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
        /// ����
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
                System.Windows.MessageBox.Show("�������ݿ�ʧ�ܣ�������Ϣ��" + ex.Message, "����");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("������Ч�������ַ�����������Ϣ��" + ex.Message, "����");
            }
        }

        /// <summary>
        /// ��ʼ������
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

            //Ĭ��ѡ���е�һ��
            keyValueModel = dbList[1];

            //��ȡ�����ַ���
            connStr = ToolsEx.ConfigValue("ConnStr");

            InitBaseSqlHelper();
        }

        /// <summary>
        /// ���ɴ���
        /// </summary>
        private void GenerateCodeTask()
        {
            if (string.IsNullOrWhiteSpace(selectFilePath))
            {
                System.Windows.MessageBox.Show("��ѡ���������·��", "��ܰ��ʾ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<ListBoxModel> listBoxModels = listBoxModel.Where(w => w.IsCheck == true).ToList();
            if (listBoxModels == null || listBoxModels.Count <= 0)
            {
                System.Windows.MessageBox.Show("û�п����ɵı�ʵ��", "��ܰ��ʾ", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            System.Windows.MessageBox.Show("���ɳɹ�", "��ܰ��ʾ", MessageBoxButton.OK, MessageBoxImage.Information);
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
        /// ѡ��������ɵ�·��
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
        /// �л�������
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
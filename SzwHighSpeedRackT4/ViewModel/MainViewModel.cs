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

        private string BaseDirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory;

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
                //ÿһ�ε������,���listbox
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

            //Ĭ��ѡ���еڶ���
            keyValueModel = dbList[1];

            //��ȡ�����ַ���
            connStr = ToolsEx.ConfigValue("ConnStr");

            InitBaseSqlHelper();

            //��ʼ��ģ������������
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

                    string path = Path.Combine(BaseDirectoryPath, TemplateInfo.Value);
                    CreateCode.CreatT4Class(templateModel, selectFilePath, path, ListBoxModelTemplate.Where(w => w.IsCheck == true).ToList());
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
        /// �л����ݿ�����������
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
        /// �л�ģ��������
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
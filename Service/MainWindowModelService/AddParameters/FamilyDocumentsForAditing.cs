using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowModelService
    {
        internal List<FamilyDocumentModel> OpenFamilyDocuments()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = ".rfa files (*.rfa)|*.rfa",
                Multiselect = true
            };

            List<FamilyDocumentModel> list = new List<FamilyDocumentModel>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    list.Add(new FamilyDocumentModel
                    {
                        FileName = Path.GetFileName(fileName),
                        FilePath = fileName
                    });
                }
            }

            if (list.Any()) return list;
            return null;
        }
    }
}

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSharedParametersToFamilies
{
    public class SharedParametersWindowModelService
    {
        private UIApplication app;
        private UIDocument uidoc;
        private Document doc;
        private RevitEvent revitEvent;
        private DefinitionFile sharedParametersFile;

        public SharedParametersWindowModelService(UIApplication app)
        {
            this.app = app;
            uidoc = app.ActiveUIDocument;
            doc = uidoc.Document;
            revitEvent = new RevitEvent();
            sharedParametersFile = doc.Application.OpenSharedParameterFile();
        }

        internal List<string> GetGroupsOfSharedParameters()
        {
            List<string> list = new List<string>();
            if (sharedParametersFile != null)
            {
                using (IEnumerator<DefinitionGroup> enumerator = sharedParametersFile.Groups.GetEnumerator())
                {
                    while (enumerator.MoveNext()) list.Add(enumerator.Current.Name);
                }
            }
            else
            {
                TaskDialog.Show("Ошибка открытия файла общих параметров", "Файл общих параметров не подключен к проекту.");
            }

            if (list.Any())
            {
                list.OrderBy(g => g).ToList();
                return list;
            }
            return null;
        }

        internal List<Definition> GetListOfSharedParameters(string selectedGroupOfSharedParameters)
        {
            List<Definition> list = new List<Definition>();
            using (IEnumerator<DefinitionGroup> enumerator = sharedParametersFile.Groups.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Name == selectedGroupOfSharedParameters)
                    {
                        foreach (Definition definition in enumerator.Current.Definitions)
                        {
                            list.Add(definition);
                        }
                        break;
                    }
                }
            }

            if (list.Any())
            {
                list.Sort((x, y) => string.Compare(x.Name, y.Name));
                return list;
            }
            return null;
        }

        internal static Document OpenFamiyDocument()
        {
            throw new NotImplementedException();
        }
    }
}

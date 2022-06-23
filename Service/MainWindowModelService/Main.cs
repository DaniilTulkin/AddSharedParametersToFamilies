using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowModelService
    {
        private UIApplication app;
        private UIDocument uidoc;
        private Document doc;
        private RevitEvent revitEvent;

        public MainWindowModelService(UIApplication app)
        {
            this.app = app;
            uidoc = app.ActiveUIDocument;
            doc = uidoc.Document;
            revitEvent = new RevitEvent();
        }

        internal void AddFamilyDocumentsInformation(ObservableCollection<FamilyDocumentModel> familyDocumentsForAditing, 
                                                    ObservableCollection<FamilyDocumentModel> familyDocumentsForReplacing,
                                                    ObservableCollection<FamilyParameter> familyParametersForReplacing)
        {
            List<FamilyParameter> familyParameters = new List<FamilyParameter>();
            foreach (Document doc in app.Application.Documents)
            {
                if (doc.IsFamilyDocument)
                {
                    FamilyDocumentModel familyDocumentModel = new FamilyDocumentModel
                    {
                        FileName = doc.Title,
                        FilePath = "OpenedFromProject"
                    };
                    familyDocumentsForAditing.Add(familyDocumentModel);
                    familyDocumentsForReplacing.Add(familyDocumentModel);

                    FamilyManager familyManager = doc.FamilyManager;
                    IList<FamilyParameter> familyManagerParameters = familyManager.GetParameters();
                    foreach (FamilyParameter familyParameter in familyManagerParameters) familyParameters.Add(familyParameter);
                }
            }

            foreach (FamilyParameter familyParameter in familyParameters.GroupBy(x => x.Definition.Name)
                                                                        .Select(x => x.First())
                                                                        .OrderBy(x => x.Definition.Name))
            {
                familyParametersForReplacing.Add(familyParameter);
            }
        }
    }
}

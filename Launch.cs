using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Linq;

namespace AddSharedParametersToFamilies.Model
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class AddSharedParametersToFamilies : IExternalEventHandler /*IExternalCommand*/
    {
        public void Execute(UIApplication app)
        {
            try
            {
                using (MainWindow mainWindow = new MainWindow(app))
                {
                    mainWindow?.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }
        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        //{
        //    try
        //    {
        //        using (MainWindow mainWindow = new MainWindow(commandData.Application))
        //        {
        //            mainWindow?.ShowDialog();
        //            foreach (Document document in commandData.Application.Application.Documents)
        //            {
        //                if (!new UIDocument(document).GetOpenUIViews().Any())
        //                {
        //                    document.Close(true);
        //                }
        //            }
        //        }
        //        return Result.Succeeded;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failed;
        //    }
        //}


        public string GetName() => nameof(AddSharedParametersToFamilies);
    }
}

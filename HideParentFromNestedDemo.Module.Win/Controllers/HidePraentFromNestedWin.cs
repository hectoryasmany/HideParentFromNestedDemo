using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HideParentFromNestedDemo.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class HidePraentFromNestedWin : ViewController
    {
        NewObjectViewController newObjectController;
        static bool nested;
        public HidePraentFromNestedWin()
        {
            InitializeComponent();
           
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            
            newObjectController = Frame.GetController<NewObjectViewController>();
            newObjectController.LinkNewObjectToParentImmediately = true;
            newObjectController.NewObjectAction.Execute += NewObjectAction_Execute;
            var appearenceController = Frame.GetController<AppearanceController>();
            appearenceController.CustomApplyAppearance += AppearenceController_CustomApplyAppearance;
            // Perform various tasks depending on the target View.
        }

        private void NewObjectAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            nested = false;

            if (Frame is NestedFrame)
            {
                if (((NestedFrame)Frame).ViewItem.CurrentObject != null)
                {
                    object Parent = ((NestedFrame)Frame).ViewItem.CurrentObject;                    
                    nested = true;
                }
            }
        }
        private void AppearenceController_CustomApplyAppearance(object sender, ApplyAppearanceEventArgs e)
        {
            DXPropertyEditor dxEditor = e.Item as DXPropertyEditor;
            if (dxEditor != null && dxEditor.Control != null&& nested && dxEditor.Caption=="Country")
            {
                ((IAppearanceVisibility)dxEditor).Visibility = ViewItemVisibility.Hide;
               
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}

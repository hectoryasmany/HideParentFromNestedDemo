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
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using HideParentFromNestedDemo.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HideParentFromNestedDemo.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class HideParentFromNested : ViewController
    {
        NewObjectViewController newObjectController;
        public HideParentFromNested()
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
            newObjectController.NewObjectAction.ExecuteCompleted += NewObjectAction_ExecuteCompleted;
           
            // Perform various tasks depending on the target View.
        }

        
        private void NewObjectAction_ExecuteCompleted(object sender, ActionBaseEventArgs e)
        {
          
        }

        private void NewObjectAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            
            var nested = ObjectSpace.CreateObject<XPObject>() ;
            if (Frame is NestedFrame)
            {
                if (((NestedFrame)Frame).ViewItem.CurrentObject != null)
                {
                    var Parent = ((NestedFrame)Frame).ViewItem.CurrentObject;
                    
                }
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

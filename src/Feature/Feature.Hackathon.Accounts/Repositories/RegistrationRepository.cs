using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feature.Hackathon.Accounts.Models;
using Foundation.Hackathon.Helpers.Helpers;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Workflows;

namespace Feature.Hackathon.Accounts.Repositories
{
    public class RegistrationRepository
    {
        private readonly ID _EventsRoot = new ID("{56A2C847-603D-4941-9EC4-65CAC9E11AE7}");
        private readonly ID _TeamTemplateId = new ID("{D83937F3-2F5D-41A3-8868-03F148ED43F2}");
        private readonly string _WorkflowId = "{BA1FAB67-75F7-420B-B44E-053F89490C6B}";

        public void CreateTeamItem(RegistrationForm formData)
        {
            Database master = Database.GetDatabase("master");
            using (new Sitecore.Data.DatabaseSwitcher(master))
            {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {


                    var template = master.GetTemplate(_TeamTemplateId);

                    Item parentItem = GetCurrentRegistrationEvent(master);

                    Item newItem = parentItem.Add(formData.TeamName, template);

                    newItem.Editing.BeginEdit();
                    try
                    {
                        newItem.Fields["Team Name"].Value = formData.TeamName;

                        newItem.Fields["Participant 1 Name"].Value = formData.Name1;
                        newItem.Fields["Participant 1 Email"].Value = formData.Email1;
                        newItem.Fields["Participant 1 Twitter"].Value = formData.Twitter1;
                        newItem.Fields["Participant 1 LinkedIn"].Value = formData.LinkedIn1;

                        newItem.Fields["Participant 2 Name"].Value = formData.Name2;
                        newItem.Fields["Participant 2 Email"].Value = formData.Email2;
                        newItem.Fields["Participant 2 Twitter"].Value = formData.Twitter2;
                        newItem.Fields["Participant 2 LinkedIn"].Value = formData.LinkedIn2;

                        newItem.Fields["Participant 3 Name"].Value = formData.Name3;
                        newItem.Fields["Participant 3 Email"].Value = formData.Email3;
                        newItem.Fields["Participant 3 Twitter"].Value = formData.Twitter3;
                        newItem.Fields["Participant 3 LinkedIn"].Value = formData.LinkedIn3;


                        IWorkflow wf = master.WorkflowProvider.GetWorkflow(_WorkflowId);
                        wf.Start(newItem);

                        newItem.Editing.EndEdit();
                    }
                    catch (System.Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.Message, this);
                        newItem.Editing.CancelEdit();
                    }
                }
            }
            
        }

        private Item GetCurrentRegistrationEvent(Database database)
        {
            var eventsRootItem = database.GetItem(_EventsRoot);
            var events = ItemHelper.GetMultiListParameterItemsList(eventsRootItem["Events"], database);
            foreach (var eventsc in events)
            {
                DateField eventStartDate = eventsc.Fields["Start Registration Date"];
                DateField eventEndDate = eventsc.Fields["End Registration Date"];
                var eventStartDateTime = eventStartDate.DateTime;
                var eventEndDateTime = eventEndDate.DateTime;
                if (eventStartDateTime <= DateTime.UtcNow && eventEndDateTime >= DateTime.UtcNow)
                {
                    return eventsc;
                }
            }

            return null;
        }
    }
}
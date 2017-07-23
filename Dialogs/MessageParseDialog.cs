using DhlBot.Properties;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace DhlBot.Dialogs
{
    [LuisModel("129bc69d-c43d-4d71-9a2a-cb9b333c3016", "eda1999f68444633a904c300cad5eff7")]
    [Serializable]
    public class MessageParseDialog : LuisDialog<object>
    {
        public async Task RootMethod (IDialogContext context, Func<Task> logic)
        {
            await logic.Invoke();
            context.Wait(MessageReceived);
        }

        #region customer service FAQs
        [LuisIntent("")]
        public async Task IntentNotFoundMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.IntentNotFoundMessage));
        }
        [LuisIntent("damageClaim")]
        public async Task DamageClaimMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.DamageClaimMessage));
        }
        [LuisIntent("exportAdvise")]
        public async Task ExportAdviseMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.ExportAdviseMessage));
        }
        [LuisIntent("importDuty")]
        public async Task ImportDutyMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.ImportDutyMessage));
        }
        [LuisIntent("lateDelivery")]
        public async Task LateDeliveryMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.LateDeliveryMessage));
        }
        [LuisIntent("packageSize")]
        public async Task PackageSizeMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.PackageSizeMessage));
        }
        [LuisIntent("paymentMethods")]
        public async Task PaymentMethodsMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.PaymentMethodsMessage));
        }
        [LuisIntent("shipmentArrival")]
        public async Task ShipmentArrivalMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.ShipmentArrivalMessage));
        }
        [LuisIntent("shippingCosts")]
        public async Task ShippingCostsMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.ShippingCostsMessage));
        }
        #endregion

        //tracking Faqs
        #region Tracking FAQs

        [LuisIntent("noTrackingNumber")]
        public async Task NoTrackingNumberMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.NoTrackingNumberMessage));
        }

        [LuisIntent("invalidWaybill")]
        public async Task InvalidWaybillMessage (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.InvalidWaybillMessage));
        }

        [LuisIntent("notIntendedDestination")]
        public async Task NotIntendedDestination (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.NotIntendedMessage));
        }

        [LuisIntent("contactDhl")]
        public async Task ContactDhl (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.ContactDhlMessage));
        }

        [LuisIntent("accountCustomer")]
        public async Task AccountCustomer (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.AccountCustomerMessage));
        }

        [LuisIntent("notificationsSignup")]
        public async Task NotificationsSignup (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.NotificationsSignupMessage));
        }

        [LuisIntent("customStatusUpdated")]
        public async Task CustomStatusUpdated (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.CustomStatusMessage));
        }

        [LuisIntent("furtherDetails")]
        public async Task FurtherDetails (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.FurtherDetailsMessage));
        }

        [LuisIntent("differentTown")]
        public async Task DifferentTown (IDialogContext context, LuisResult luisResult)
        {
            await RootMethod(context, async () => await context.PostAsync(Resources.DifferentTownMessage));
        }
        #endregion

        [LuisIntent("register")]
        public async Task Register (IDialogContext context, LuisResult luisResult)
        {
            context.Call(MakeRootDialog(), ConversationComplete);
            await context.PostAsync("Type continue to fill form");
        }

        private Task ConversationComplete (IDialogContext context, IAwaitable<object> result)
        {
            context.Done(this);
            return Task.CompletedTask;
        }

        internal static IDialog<RegisterForm> MakeRootDialog ()
        {
            return Chain.From(() => FormDialog.FromForm(RegisterForm.BuildForm));
        }

    }
}
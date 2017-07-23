using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;

namespace DhlBot.Dialogs
{
    public enum JobTitle
    {
        Test,
        Consultant,
        DepartmentManager,
        ManagementAssistant,
        ManagingDirector,
        OtherEmployee,
        SelfEmployed

    }
    public enum Salutation
    {
       Test,
        Mister,
        Mrs
    }

    [Serializable]
    public class RegisterForm
    {
        public string companyName;
        public string vatNo;

        [Pattern(@"^\d{10}$")]
        public string companyPhone;

        public string streetName;
        public int streetNumber;
        public string city;
        public string country;
        public bool courierPickups;

        public string firstName;
        public string lastName;
        public JobTitle jobTitle;
        public Salutation salutation;

        [Pattern(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string email;

        [Pattern(@"^\d{10}$")]
        public string officePhone;
        public string userId;

        [Pattern(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string password;

        public static IForm<RegisterForm> BuildForm ()
        {
            return new FormBuilder<RegisterForm>().Message("Fill the following form to register")
                .OnCompletion(async (context, registerForm) => {
                    await context.PostAsync("Thank you for registering. Have a nice day");
                })
                .Build();
        }
    }
}
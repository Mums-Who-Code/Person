// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Brokers.Loggings;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService : IPersonService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingbroker;

        public PersonService(IStorageBroker storageBroker,
                             ILoggingBroker loggingbroker)

        {
            this.storageBroker = storageBroker;
            this.loggingbroker = loggingbroker;
        }

       public Person AddPerson(Person person) =>
          Trycatch(() =>
            {
                ValidatePerson(person);

                return this.storageBroker.InsertPerson(person);
            });
    }
}
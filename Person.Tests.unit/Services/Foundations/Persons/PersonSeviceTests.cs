// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Services.Foundations.Persons;


namespace Person.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonSeviceTests
    {
        private readonly IPersonServices personServices;
        private readonly Mock<IStorageBroker> storageBrokerMock;

        public PersonSeviceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.personServices = new PersonService(
                 this.storageBrokerMock.Object);
         }
    }
}


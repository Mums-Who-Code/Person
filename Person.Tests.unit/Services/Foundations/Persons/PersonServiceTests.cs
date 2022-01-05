// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Services.Foundations.Persons;

namespace Person.Tests.unit.Services.Foundations.Persons
{
    internal class PersonServiceTests
    {
        private readonly Mock<IStorageBroker> storagebrokermock;
        private readonly IPersonService personService;

        public PersonServiceTests()
        {
            this.storagebrokermock = new Mock<IStorageBroker>();

            this.personService = new PersonService(
                storageBroker: this.storagebrokermock.Object);

        }
    }
}

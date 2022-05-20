// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using PersonApp.ConsoleApp.Brokers.Loggings;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Services.Foundations.Persons;
using Tynamix.ObjectFiller;
using Xeptions;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IPersonService personService;

        public PersonServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.personService = new PersonService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
              actualException.Message == expectedException.Message
              && actualException.InnerException.Message == expectedException.InnerException.Message
              && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static List<Person> CreateRandomPersons() =>
            CreatePersonFiller().Create(count: GetRandomNumber()).ToList();

        private Person CreateRandomPerson() =>
          CreatePersonFiller().Create();

        private static Filler<Person> CreatePersonFiller() =>
             new Filler<Person>();
    }
}
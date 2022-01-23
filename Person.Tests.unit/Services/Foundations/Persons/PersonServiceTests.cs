// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Services.Foundations.Persons;
using Tynamix.ObjectFiller;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        private readonly Mock<IStorageBroker> storagebrokermock;
        private readonly IPersonService personService;

        public PersonServiceTests()
        {
            this.storagebrokermock = new Mock<IStorageBroker>();

            this.personService = new PersonService(
                 this.storagebrokermock.Object);
        }
      
        private static Person CreateRandomPerson() =>
          CreatePersonFiller().Create();
        

        private static Filler<Person> CreatePersonFiller() =>
            new Filler<Person>();
        }
    }

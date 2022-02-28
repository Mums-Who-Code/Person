// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfPersonIsNullAndLogIt()
        {
            // given
            Person nullPerson = null;
              var nullPersonException = new NullPersonException();

            var exceptedPersonValidationException =
                new PersonvalidationException(nullPersonException);

            //when
            Action addPersonAction = () => this.personService.ADDPerson(nullPerson);

            //then
            Assert.Throws<PersonvalidationException>(addPersonAction);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs
               (exceptedPersonValidationException))),
                  Times.Once);

            this.storagebrokermock.Verify(broker =>
               broker.InsertPerson(It.IsAny<Person>()),
                  Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storagebrokermock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]

        public async Task ShouldThrowValidationExceptionOnAddIfPersonIsInvalidAndLogIt(
            string invalidFirstName)
        {
            //given 
            Person invalidPerson = new Person
            {
                FirstName = invalidFirstName,
            };
            var invalidPersonException = new InvalidPersonException();

            invalidPersonException.AddData(
                key: nameof(Person.Id),
                values: "ID is Required. ");

            invalidPersonException.AddData(
                key: nameof(Person.FirstName),
                values: " FirstName is required.");


            var exceptedPersonvalidationException = new PersonvalidationException(invalidPersonException);

            //when 
            Action addPersonAction = () => this.personService.ADDPerson(invalidPerson);

            ///then

            Assert.Throws<PersonvalidationException>(addPersonAction);

            this.loggingBrokerMock.Verify(broker =>
              broker.LogError(It.Is(SameExceptionAs
                 (exceptedPersonvalidationException))),
                    Times.Once);

            this.storagebrokermock.Verify(broker =>
                broker.InsertPerson(It.IsAny<Person>()),
                  Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storagebrokermock.VerifyNoOtherCalls();
        }
    }
 }
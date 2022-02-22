// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfPersonIsNullAndLogIt()
        {
            //given
            Person nullPerson = null;
            var nullPersonException = new NullPersonException();

            var exceptedPersonValidationException =
                new PersonvalidationException(nullPersonException);

            //when
            Action addPersonAction = () => this.personService.ADDPerson(nullPerson);

            //then
            Assert.Throws<PersonvalidationException>(addPersonAction);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(exceptedPersonValidationException))),
              Times.Once);

            this.storagebrokermock.Verify(broker =>
            broker.InsertPerson(It.IsAny<Person>()),
            Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storagebrokermock.VerifyNoOtherCalls();
        }
    }
}
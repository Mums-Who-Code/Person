// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowValidateExceptionOnModifyIfPersonIsNulAndLogIt()
        {
            //given
            Person nullPerson = null;
            var nullPersonExpection = new NullPersonException();
            var expectedPersonValidationException =
                new PersonValidationException(nullPersonExpection);

            //when
            Action modifyPersonAction = () => this.personService.ModifyPerson(nullPerson);

            //then
            Assert.Throws<PersonValidationException>(modifyPersonAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPersonValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdatePerson(It.IsAny<Person>()),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}

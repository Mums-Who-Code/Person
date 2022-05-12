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
        public void ShouldThrowValidationExceptionOnRetrieveByIdIsInvalid()
        {
            //given
            int invalidId = default;
            var invalidPersonException = new InvalidPersonException();

            invalidPersonException.AddData(
                key: nameof(Person.Id),
                values: "ID is required.");

            var expectedPersonValidationException =
                 new PersonValidationException(invalidPersonException);

            //when
            Action retrievePersonByIdAction = () =>
            this.personService.RetrievePersonById(invalidId);

            //then
            Assert.Throws<PersonValidationException>(retrievePersonByIdAction);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                  expectedPersonValidationException))),
                     Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectPersonById(It.IsAny<int>()),
                   Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
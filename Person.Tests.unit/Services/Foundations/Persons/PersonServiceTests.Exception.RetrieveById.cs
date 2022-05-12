// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyValidationExceptionOnRetrieveByIdIfValidationErrorOccursAndLogIt()
        {
            //given
            int somePersonId = GetRandomNumber();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentPersonException =
                 new NullArgumentPersonException(argumentNullException);

            var expectedPersonDepencyValidationException =
                new PersonDependencyValidationException(nullArgumentPersonException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPersonById(It.IsAny<int>()))
                   .Throws(argumentNullException);

            //when
            Action retrievePersonByIdAction = () =>
                this.personService.RetrievePersonById(somePersonId);

            //then
            Assert.Throws<PersonDependencyValidationException>(retrievePersonByIdAction);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPersonById(It.IsAny<int>()),
                   Times.Once());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs
                  (expectedPersonDepencyValidationException))),
                     Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
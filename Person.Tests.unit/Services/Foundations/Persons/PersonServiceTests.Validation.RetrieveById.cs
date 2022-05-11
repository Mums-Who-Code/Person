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
            var invalidPerson = new Person();
            var invalidPersonException = new InvalidPersonException();

            invalidPersonException.AddData(
                key: nameof(Person.Id),
                      values: "Id is required");

            var expectedPersonvalidationException = 
                new PersonvalidationException(invalidPersonException);

            //when
            Action retrieveByIdAction = () =>
             this.personService.RetrievePersonById(invalidPerson.Id);

            //then
            Assert.Throws<PersonvalidationException>(retrieveByIdAction);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                  expectedPersonvalidationException))),
                     Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectPersonById(It.IsAny<int>()),
                   Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();


        }

    }
}

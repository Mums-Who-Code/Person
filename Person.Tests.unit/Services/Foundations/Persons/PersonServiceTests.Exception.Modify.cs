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
        public void ShouldThrowDependencyValidationExceptionOnModifyIfValidationErrorOccursAndLogIt()
        {
            //given
            Person somePerson = CreateRandomPerson();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentPersonException =
                new NullArgumentPersonException(argumentNullException);


            var expectedPersonDependencyValidationException =
                new PersonDependencyValidationException(nullArgumentPersonException);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdatePerson(It.IsAny<Person>())).
                    Throws(argumentNullException);
            //when
            Action modifyPersonException = () => this.personService.ModifyPerson(somePerson);

            //then
            Assert.Throws<PersonDependencyValidationException>(modifyPersonException);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdatePerson(It.IsAny<Person>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs
                    (expectedPersonDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }

    }
}

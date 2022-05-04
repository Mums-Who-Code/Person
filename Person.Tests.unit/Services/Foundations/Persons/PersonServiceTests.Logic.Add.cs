// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
   public partial class PersonServiceTests
   {
        [Fact]
        public void ShouldAddPerson()
        {
            //given
            Person randomperson = CreateRandomPerson();
            Person inputPerson = randomperson;
            Person presistedPerson = inputPerson;
            Person expectedPerson = presistedPerson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
              broker.InsertPerson(inputPerson))
                 .Returns(presistedPerson);
            //when
            Person actualperson = this.personService.AddPerson(inputPerson);

            //then
            actualperson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertPerson(inputPerson),
                   Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
   }
}
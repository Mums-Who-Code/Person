// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    partial class PersonServiceTests
    {
        [Fact]
        public void ShouldAddPerson()
        {
           //given
            Person randomperson = CreateRandomPerson();
            Person inputPerson = randomperson ;
            Person presistedPerson = inputPerson;
            Person expectedPerson = presistedPerson;
           
            this.storagebrokermock.Setup(broker =>
            broker.InsertPerson(presistedPerson))
                .Returns(presistedPerson);
            //when
             Person actualperson = this.personService.ADDPerson(presistedPerson);
            
            //then
            actualperson.Should().BeEquivalentTo(expectedPerson);

            this.storagebrokermock.Verify(broker =>
           broker.InsertPerson(inputPerson), Times.Once);

            this.storagebrokermock.VerifyNoOtherCalls();
                
        }
    }
}

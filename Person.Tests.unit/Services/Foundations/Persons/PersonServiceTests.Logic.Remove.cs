﻿// ------------------------------------------------
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
        public void ShouldRemovePerson()
        {
            //given
            Person randomPerson = CreateRandomPerson();
            Person inputPerson = randomPerson;
            Person deletedPerson = inputPerson;
            Person expectedPerson = deletedPerson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.DeletePerson(inputPerson)).
                    Returns(deletedPerson);

            //when
            Person actualPerson = this.personService.RemovePerson(inputPerson);

            //then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
                broker.DeletePerson(inputPerson),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
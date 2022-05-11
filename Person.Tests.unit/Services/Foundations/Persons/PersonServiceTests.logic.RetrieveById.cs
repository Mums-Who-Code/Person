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
        public void ShouldRetrievePersonById()
        {
            //given
            Person randomPerson = CreateRandomPerson();
            Person inputPerson = randomPerson;
            Person storageperson = inputPerson;
            Person expectedPerson = storageperson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.SelectPersonById(inputPerson.Id))
                .Returns(storageperson);
            //when
            Person actualPerson =
                this.personService.RetrievePersonById(inputPerson.Id);

            //then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
            broker.SelectPersonById(inputPerson.Id), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }

    }
}

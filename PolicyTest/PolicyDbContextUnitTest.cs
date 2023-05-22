using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PolicyModels;
using PolicyQueries;
using WebApplicationPolicyAPI.Controllers;

namespace PolicyTest
{
    [TestFixture]
    public class PolicyDbContextUnitTest
    {
        /// <summary>
        /// Check if the CreatePolicy method returns an OkResult when a valid policy is provided
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreatePolicyValidPolicyReturnsOkResult()
        {
            // Arrange
            var mockCreatePolicy = new Mock<CreatePolicy>();
            var mockGetPolicy = new Mock<GetPolicy>();
            var controller = new PolicyController(mockCreatePolicy.Object, mockGetPolicy.Object);

            var policy = new InsurancePolicy { NumeroPoliza = "ABC123", NombreCliente = "John Doe" };

            // Act
            var result = await controller.CreatePolicy(policy);

            // Assert
            Assert.That(result, Is.TypeOf<OkResult>());
        }

        /// <summary>
        /// Verify if the CreatePolicy method returns a BadRequestResult when an invalid policy is provided
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreatePolicyInvalidPolicyReturnsBadRequest()
        {
            // Arrange
            var mockCreatePolicy = new Mock<CreatePolicy>();
            var mockGetPolicy = new Mock<GetPolicy>();
            var controller = new PolicyController(mockCreatePolicy.Object, mockGetPolicy.Object);

            var policy = new InsurancePolicy(); // Invalid policy without required properties

            // Act
            var result = await controller.CreatePolicy(policy);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        /// <summary>
        /// Verify if the CreatePolicy method correctly adds the policy to the context
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreatePolicy_PolicySavedSuccessfully()
        {
            // Arrange
            var mockContext = new Mock<PolicyDbContext>();
            var mockCreatePolicy = new Mock<CreatePolicy>();
            var mockGetPolicy = new Mock<GetPolicy>();
            var controller = new PolicyController(mockCreatePolicy.Object, mockGetPolicy.Object);

            var policy = new InsurancePolicy { NumeroPoliza = "ABC123", NombreCliente = "John Doe" };

            // Act
            var result = await controller.CreatePolicy(policy);

            // Assert
            mockContext.Verify(c => c.Add(policy), Times.Once);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}

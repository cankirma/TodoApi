using Domain.Entities;
using Infrastructure.Authentication;
using Infrastructure.Security;
using System.IdentityModel.Tokens.Jwt;

namespace Todo.Infrastructure.UnitTests.Authentication


{
    public class JwtTokenGeneratorTests
    {
        [Fact]
        public void GenerateToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "email@example.com",
                Password = HashUtil.Hash("123456"),
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var jwtTokenGenerator = new JwtTokenGenerator();

            // Act
            var token = jwtTokenGenerator.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrEmpty(token));
        }


        [Fact]
        public void GenerateToken_ValidUser_TokenHasCorrectClaims()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "email@example.com",
                Password = HashUtil.Hash("123456"),
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var jwtTokenGenerator = new JwtTokenGenerator();

            // Act
            var token = jwtTokenGenerator.GenerateToken(user);

            // Assert
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            Assert.Equal(user.Id.ToString(), decodedToken.Subject);
            Assert.Equal(user.FirstName, decodedToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.GivenName).Value);
            Assert.Equal(user.LastName, decodedToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.FamilyName).Value);
        }

        [Fact]
        public void GenerateToken_ValidUser_TokenHasValidIssuerAndAudience()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "email@example.com",
                Password = HashUtil.Hash("123456"),
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var jwtTokenGenerator = new JwtTokenGenerator();

            // Act
            var token = jwtTokenGenerator.GenerateToken(user);

            // Assert
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            Assert.Equal("ottoo", decodedToken.Issuer);
            Assert.True(decodedToken.Audiences.Contains("ottoo"));
        }

        [Fact]
        public void GenerateToken_ValidUser_TokenHasValidExpirationTime()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "email@example.com",
                Password = HashUtil.Hash("123456"),
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var jwtTokenGenerator = new JwtTokenGenerator();

            // Act
            var token = jwtTokenGenerator.GenerateToken(user);

            // Assert
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            Assert.True(decodedToken.ValidTo > DateTime.UtcNow);
            Assert.True(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(61));
        }
    }
}

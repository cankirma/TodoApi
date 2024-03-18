using Infrastructure.Security;

namespace Todo.Infrastructure.UnitTests.Security;

public class HashUtilTests
{
    private const string TestString = "TestString";

    [Fact]
    public void Hash_GivenString_ReturnsHashedString()
    {
        // Act
        var hashedString = HashUtil.Hash(TestString);

        // Assert
        Assert.NotNull(hashedString);
        Assert.NotEmpty(hashedString);
        Assert.Contains(':', hashedString); 
    }

    [Fact]
    public void Verify_GivenCorrectStringAndHash_ReturnsTrue()
    {
        // Arrange
        var hashedString = HashUtil.Hash(TestString);

        // Act
        var result = HashUtil.Verify(TestString, hashedString);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Verify_GivenIncorrectStringAndHash_ReturnsFalse()
    {
        // Arrange
        var hashedString = HashUtil.Hash(TestString);

        // Act
        var result = HashUtil.Verify("IncorrectString", hashedString);

        // Assert
        Assert.False(result);
    }
}
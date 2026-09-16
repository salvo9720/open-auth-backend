using System.Diagnostics;

namespace open_auth_backend.Tests;

public class PassowrdHash
{
    [Fact]
    public void samePasswordNotForSameHash()
    {
        string password = "admin";

        string hash1 = BCrypt.Net.BCrypt.HashPassword(password);
        string hash2 = BCrypt.Net.BCrypt.HashPassword(password);
        Debug.WriteLine($"Hash: {hash1}"); ;

        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void checkPasswordByHash()
    {
        string password = "admin";

        string hash1 = BCrypt.Net.BCrypt.HashPassword(password);
        string hash2 = BCrypt.Net.BCrypt.HashPassword(password);

        Assert.True(BCrypt.Net.BCrypt.Verify(password, hash1));
        Assert.True(BCrypt.Net.BCrypt.Verify(password, hash2));
    }

    [Fact]
    public void DifferentPasswordDifferentHash()
    {
        string password = "admin";

        string hash = BCrypt.Net.BCrypt.HashPassword(password);

        Assert.False(BCrypt.Net.BCrypt.Verify("passwordSbagliata", hash));
    }
}

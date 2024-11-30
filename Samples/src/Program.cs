using HashingHandler;
using HashingHandler.Formats.String;
using System.IO.Hashing;
using System.Security.Cryptography;
using System.Text;

namespace HashingHandlerSamples;

class Program
{
    static void Main(string[] args)
    {
        // Synchronous Only
        /*
        IHashingAlgorithm<string> sha256 = new SHA256Hasher();
        IHashingAlgorithm<string> xxh3 = new XXH3Hasher();
        IHashingAlgorithm<string> xor = new XORHash();
        */

        // Synchronous and Asynchronous
        IHashingAlgorithmAsync<string> sha256 = new SHA256Hasher();
        IHashingAlgorithmAsync<string> xxh3 = new XXH3Hasher();
        IHashingAlgorithmAsync<string> xor = new XORHash();

        // Hash provider of string data
        IHashingProvider<string> provider = new StringHashProvider(Encoding.UTF8);

        // Synchronous Only
        /*
        IHashVerifier<string> stringVerifier = new StringHashVerifier();
        */

        // Synchronous and Asynchronous
        IHashVerifierAsync<string> stringVerifier = new StringHashVerifier();

        // Base64 encoding of hash bytes
        IStringEncodingAsync base64 = new Base64Hashes();

        while (true)
        {
            Console.Write("Enter some text: ");
            string text = Console.ReadLine() ?? string.Empty;

            // Sha256
            string hashSha256 = sha256.ComputeHash(text, provider);
            bool matchSha = stringVerifier.VerifyHash(text, hashSha256, sha256); // True, hashes match

            // Sha256 in base64
            string hashSha256Base64 = sha256.ComputeHash(text, provider, encoding: base64);
            bool matchShaBase64 = stringVerifier.VerifyHash(text, hashSha256Base64, sha256, encoding: base64); // True, hashes match

            // Xxh3
            string hashXxh3 = xxh3.ComputeHash(text, provider);
            bool matchXxh3 = stringVerifier.VerifyHash(text, hashXxh3, xxh3); // True, hashes match

            // XOR
            string hashXor = xor.ComputeHashAsync(text, provider).GetAwaiter().GetResult();
            bool matchXor = stringVerifier.VerifyHash(text, hashXor, xor); // True, hashes match

            // False, because SHA256 and XXH3 are different algorithms that produce different hashes for the same data.
            bool testFail = stringVerifier.VerifyHash(text, hashXxh3, sha256);

            // False, because sha256 is not encoded in base64
            bool testFail2 = stringVerifier.VerifyHash(text, hashSha256, sha256, base64);

            Console.WriteLine();
            Console.WriteLine($"SHA256: {hashSha256} {matchSha}");
            Console.WriteLine($"SHA256 Base64: {hashSha256Base64} {matchShaBase64}");
            Console.WriteLine($"XXH3: {hashXxh3} {matchXxh3}");
            Console.WriteLine($"XOR: {hashXor} {matchXor}");
            Console.WriteLine($"Fail test success: {!testFail} {!testFail2}");
            Console.WriteLine();
        }
    }
}

class Base64Hashes : StringEncodingBase
{
    public override string ConvertToString(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
}

class SHA256Hasher : HashingCrypto<string>
{
    protected override HashAlgorithm GetAlgorithm()
    {
        return SHA256.Create(); // Returns new SHA256 object
    }
}

class XXH3Hasher(long seed = 0) : HashingNonCrypto<string>
{
    private readonly long _seed = seed;

    protected override NonCryptographicHashAlgorithm GetAlgorithm()
    {
        return new XxHash3(_seed);
    }
}

class XORHash : HashingAlgorithmBase<string>
{
    protected override byte[] ComputeHash(byte[] bytes)
    {
        // Specify the length of the payload to be hashed.
        int payloadLength = bytes.Length; // Let's hash the entire payload.

        // Specify the length of the returned hash.
        int hashLength = 8; // 8 bytes, 16 characters

        // Initialize result array to hold the hash of specified length
        byte[] result = new byte[hashLength];

        // Perform XOR on the bytes, distributing across each position in result
        for (int i = 0; i < payloadLength; i++)
        {
            result[i % hashLength] ^= bytes[i];
        }

        return result;
    }    
}
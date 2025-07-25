using Xunit;

namespace OldPhonePad.Tests
{
    public class OldPhonePadTests
    {
        [Theory]
        [InlineData("7777#", "S")]                        
        [InlineData("22 2222#", "AB")]                    
        [InlineData("44*44#", "H")]                      
        [InlineData("66 6 666#", "MON")]                  
        [InlineData("9 99 999 9999#", "WXYZ")]           
        [InlineData("777 77 7#", "RQP")]                  
        [InlineData("222*222#", "A")]                     
        [InlineData("333 33 3#", "FED")]                  
        [InlineData("5 55 555 *5#", "JK")]                
                   
        public void Decode_ShouldReturnExpectedOutput(string input, string expected)
        {
            var result = OldPhonePad.PhonePad.Decode(input);
            Assert.Equal(expected, result);
        }
    }
}
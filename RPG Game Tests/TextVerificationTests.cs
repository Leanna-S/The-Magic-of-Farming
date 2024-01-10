using RPG_Game_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class TextVerificationTests
    {
        [Fact]
        public void TextVerification_VerifyName_TextEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { TextVerification.VerifyName(" "); });
        }

        [Fact]
        public void TextVerification_VerifyName_TextTooLong_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { TextVerification.VerifyName("Is this name long? yes it is. very fun here, YAY! Why dont i cause chaos here lolololololo"); });
        }

        [Fact]
        public void TextVerification_VerifyName_TextTooShort_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { TextVerification.VerifyName("hi"); });
        }

        [Fact]
        public void TextVerification_VerifyName_ValidName_ReturnsTrue()
        {
            Assert.True(TextVerification.VerifyName("Leanna"));
        }
    }
}
using UtilGenericNugget;

namespace UnitGenericNuggetTest
{
    public class JsonUtilConverterTest
    {
        [Fact]
        public void PasarModeloAJson()
        {

            // Arrange
            var @object = new
            {
                Id="1",
                Nombre="Jose W",
                Apellido = "Santamaria"

            };

            // Act
            string result = JSONUtilConverter.GetJsonRepresentation(@object);

            // Assert
            Assert.Contains("Nombre", result);


        }
    }
}
using FlowerClient.model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

internal static class TokenLifetime
{
    public static DateTime? Lifetime()
    {
        string token = Header.headers.AccessToken; // access token

        // Создаем объект JwtSecurityTokenHandler для чтения токена
        var tokenHandler = new JwtSecurityTokenHandler();

        // Проверяем, является ли токен валидным JWT токеном
        if (tokenHandler.CanReadToken(token))
        {
            // Читаем токен
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Извлекаем дату истечения срока действия (exp) токена
            var expirationDateUnix = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value;
            if (expirationDateUnix != null)
            {
                // Преобразуем Unix время в DateTime
                var expirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationDateUnix)).UtcDateTime;
                Console.WriteLine(expirationDate);
                return expirationDate;
            }
            else
            {
                Console.WriteLine("Срок действия токена не найден.");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Некорректный JWT токен.");
            return null;
        }
    }
}
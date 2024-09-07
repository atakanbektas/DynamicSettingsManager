using Microsoft.AspNetCore.Mvc;
using Moq;
using SettingManagerApp.Domain.Entities;
using SettingManagerApp.MVCUI.Controllers;
using SettingsManagerApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Tests
{
    public class SimpleTest
    {
        [Fact]
        public void SimpleEqualityTest()
        {
            // Arrange: Test verilerini hazırlama (gerekli değil)

            // Act: Test edilecek işlemi yapma (1 == 1 kontrolü)
            var result = 1 == 1;

            // Assert: Sonucu kontrol etme
            Assert.True(result);
        }

        [Fact]
        public async Task ToggleActiveProp_ShouldToggleIsActiveProperty()
        {
            // Arrange: Test verisi ve mock servis oluştur
            var config = new AppConfiguration { Id = 1, Name = "TestConfig", IsActive = true }; // Başlangıçta aktif
            var mockConfigService = new Mock<IAppConfigService>();
            mockConfigService.Setup(s => s.GetAppConfigByIdAsync(1)).ReturnsAsync(config);

            var controller = new ConfigController(mockConfigService.Object);

            // Act: Action'ı çalıştır
            var result = await controller.ToggleActiveProp(1);

            // Assert: İlgili property'nin tersine döndüğünü kontrol et
            Assert.False(config.IsActive);  // Başlangıçta true olduğu için, false olmalı
            Assert.IsType<RedirectToActionResult>(result); // Sonuç bir yönlendirme olmalı

            // Update metodunun çağrıldığını kontrol et
            mockConfigService.Verify(s => s.UpdateAppConfig(config), Times.Once);
        }
    }
}

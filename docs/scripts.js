// Oyun detaylarını gösterme fonksiyonu
function showDetails(game) {
  let message = "";
  if (game === "fish") {
      message = "Balık Tutma oyunu, denizin derinliklerinde balıkları yakalamaya çalışırken çocukların dikkatini ve el-göz koordinasyonunu geliştirir. AR teknolojisi ile daha gerçekçi bir deneyim sunar.";
  } else if (game === "hide") {
      message = "Saklambaç oyununda, çocuklar deniz yıldızlarını bulmak için ipuçlarını takip eder. Bu oyun, çocukların problem çözme becerilerini geliştirir ve eğlenceli bir keşif yolculuğu sunar.";
  }
  alert(message);
}

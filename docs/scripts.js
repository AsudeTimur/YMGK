function showAnimation(activity) {
    const animationDiv = document.getElementById('animation');
    animationDiv.classList.add('active');
    
    const content = document.querySelector('.animation-content h3');
    if (activity === 'games') {
      content.innerText = "Oyunlar Açılıyor! 🎮";
    } else if (activity === 'videos') {
      content.innerText = "Videolar Açılıyor! 📺";
    } else if (activity === 'stories') {
      content.innerText = "Hikayeler Yükleniyor! 📖";
    } else if (activity === 'ar') {
      content.innerText = "AR Deneyimi Başlıyor! 🌐";
    }
  }
  
  function hideAnimation() {
    const animationDiv = document.getElementById('animation');
    animationDiv.classList.remove('active');
  }
  
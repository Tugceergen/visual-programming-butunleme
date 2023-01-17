-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 14 Oca 2023, 15:26:34
-- Sunucu sürümü: 8.0.28
-- PHP Sürümü: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `basketbol`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` int NOT NULL,
  `kullaniciAdi` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `kullaniciAdi`, `sifre`) VALUES
(1, 'murat', '/NRx9VU2Pdk=');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `duyuru`
--

CREATE TABLE `duyuru` (
  `id` int NOT NULL,
  `baslik` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `konu` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `duyuru`
--

INSERT INTO `duyuru` (`id`, `baslik`, `konu`) VALUES
(1, 'DUYURU', 'Türk basketbolu ile ilgili her türlü somut iddianın, ilgili kurullarımız \r\ntarafından incelenmekte ve talimatlarımıza uygun şekilde \r\ndeğerlendirilmekte olduğunu kamuoyuna saygı ile duyururuz.'),
(2, 'DUYURU', 'Tüm yurdumuzu etkisi altına alan elverişsiz hava koşulları \r\nnedeni ile 12-13 Mart 2022 tarihlerinde oynanacak tüm \r\nbasketbol müsabakaları ileri bir tarihe ertelenmiştir. \r\nKarşılaşmaların tarihleri daha sonra açıklanacaktır.\r\nKamuoyuna saygıyla duyurulur.'),
(3, 'DUYURU', 'Türkiye Basketbol Federasyonu Yönetim Kurulu, 2022-2023 sezonundan \r\nitibaren Kadınlar Basketbol Süper Ligi’nde takım kadrolarında bulunacak\r\n yabancı oyuncu sayısının en fazla üç (3) olmasına karar vermiştir.\r\n\r\nKamuoyunun bilgisine sunarız.');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `haberler`
--

CREATE TABLE `haberler` (
  `id` int NOT NULL,
  `baslik` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `konu` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `haberler`
--

INSERT INTO `haberler` (`id`, `baslik`, `konu`) VALUES
(2, 'Anadolu Efes 77 Gaziantep Basketbol 73  MAÇ SONUCU', 'Türkiye Sigorta Basketbol Süper Liginin 13. hatasında Anadolu Efes, Gaziantep Basketbolu konuk etti. Sinan Erdem Spor Salonunda oynanan mücadeleyi Anadolu Efes 77 73 kazandı.'),
(4, 'Kevin Punter: “Anadolu Efes’in 2 Yıldır EuroLeague’i Kazanmasının Nedeni…”', 'Turkish Airlines EuroLeague’de sezona inişli çıkışlı bir başlangıç yapan Partizan, son haftalarda toparlanarak üst üste galibiyetler almayı başardı. Son olarak evinde Bayern Münih’i mağlup ederek 3 maçlık bir galibiyet serisi yakalayan koç Zeljko Obradovic‘in ekibi, böylelikle playoff hattına iyice yaklaştı.'),
(5, 'NBAde Doncic şov devam ediyor.', 'NBAe 9 maçla devam edildi. Dallas Mavericks, Doncicin 51 sayı, 6 ribaunt, 9 asistle oynadığı mücadelede konuk olduğu San Antonio Spursü 126-125 yenerek üst üste 6, sezonun 21. galibiyetini aldı. Doncic böylece, son 5 maçta 3. kez 50 ve üstü sayıya ulaştı.'),
(6, 'Ankara Büyük Erkekler Basketbol Liginin Şampiyonu Abb Ego Spor Oldu', 'Ankara Büyükşehir Belediyesi (ABB) EGO Spor, Ankara Büyük Erkekler Basketbol Liginde şampiyon oldu. Kupasını kulüp başkanı Zafer Tekbudaktan alan şampiyon takımın hedefi, Türkiye Basketbol 2. Ligine yükselmek.');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `id` int NOT NULL,
  `ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `soyad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `kullaniciAdi` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `sifre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`id`, `ad`, `soyad`, `kullaniciAdi`, `sifre`) VALUES
(19, 'tuğçe', 'ergen', 'tuğçe', '/NRx9VU2Pdk=');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oyuncular`
--

CREATE TABLE `oyuncular` (
  `id` int NOT NULL,
  `baslik` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `konu` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `oyuncular`
--

INSERT INTO `oyuncular` (`id`, `baslik`, `konu`) VALUES
(1, 'CENGİZ GERMİYAN', 'Cengiz Germiyan (d. 7 Aralık 2002), Türk basketbolcudur. Kütahya Dumlupınar\nÜniversitesi\'nde okudu. Okulun Türkiye Liginde\'de final oynamasında en büyük \nrolü oynadı. 10 Numaralı formasıyla profesyonel olduğu 2018\'den bugüne kadar \n3 kez Türkiye Şampiyonluğu kazandı,defalarca final oynadı, 2 kez de Türkiye\'nin \nfinallerinin en değerlioyuncusu seçildi. 3 kez de Türkiye normal sezon MVP\'si oldu.\nBasketbolda yaratıcılığı ve oyun zekası ile tanınan oyunculardandır.\n\nCengiz Germiyan, Türkiye\'de tüm zamanların en çok triple-double yapan oyuncuları \nlistesinde ilk 10\'da yer almaktadır. Aynı zamanda 14 dakika, 33 saniye ile Türkiye \ntarihinin en hızlı triple-double yapma rekorunun sahibidir..'),
(2, 'NİKOLA JOKİC', 'Nikola Jokic (d. 19 Şubat 1995), pivot pozisyonunda görev alan Sırp profesyonel \r\nbasketbolcu. National Basketball Association (NBA) takımlarından Denver \r\nNuggets forması giymektedir. 2014 NBA Seçmeleri\'nde Denver Nuggets \r\ntarafından 2. tur, 41. sırada seçilmiştir. 4 kere NBA All-Star ve 2 kere NBA En \r\nDeğerli Oyuncu seçildi. Aynı zamanda Sırbistan millî basketbol \r\ntakımında oynamaktadır. Lakabı ise \'\'Joker\'\'dir.'),
(3, 'STEPHEN CURRY', 'Wardell Stephen Curry II (d. 14 Mart 1988), National Basketball Association \r\n(NBA) takımlarından Golden State Warriors forması giyen Amerikalı\r\nprofesyonel basketbolcudur. 1.91 boyunda 86 kg ağırlığında bulunan Curry,\r\noyun kurucu pozisyonunda görev almaktadır. Fakat Amerikalı oyuncu takımı\r\nzorda kaldığında gerektiği zaman Şutör gard pozisyonunda da oynayabilecek \r\nkapasiteye sahiptir. 2011 yılında Ayesha Curry ile evlenmiş, Riley ve \r\nRyan Carson adında iki kız çocuğu ve Canon adında bir erkek çocuğu olmuştur.');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `duyuru`
--
ALTER TABLE `duyuru`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `haberler`
--
ALTER TABLE `haberler`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanici`
--
ALTER TABLE `kullanici`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kullaniciAdi` (`kullaniciAdi`);

--
-- Tablo için indeksler `oyuncular`
--
ALTER TABLE `oyuncular`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `duyuru`
--
ALTER TABLE `duyuru`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Tablo için AUTO_INCREMENT değeri `haberler`
--
ALTER TABLE `haberler`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Tablo için AUTO_INCREMENT değeri `oyuncular`
--
ALTER TABLE `oyuncular`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

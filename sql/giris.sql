create table kullanici
(
    id int primary key identity(1,1),
	k_adi nvarchar(50),
	k_sifre nvarchar(50)
)

create table stok
(
    id int primary key identity(1,1),
	urun_kodu int,
	urun_adi nvarchar(50),
	urun_fiyati nvarchar(50),
	urun_cinsi nvarchar(50),
	urun_adedi tinyint,
	kritik_stok tinyint,
	urun_resmi nvarchar(max),
	bgn_saat nvarchar(max),
	bgn_tarih nvarchar(max),
	urun_ekleyen nvarchar(50)
)

create table satis
(
    id int primary key identity(1,1),
	urun_kodu int,
	urun_adi nvarchar(50),
	urun_fiyati nvarchar(50),
	urun_cinsi nvarchar(50),
	urun_adedi tinyint,
	bgn_saat nvarchar(max),
	bgn_tarih nvarchar(max),
	urun_ekleyen nvarchar(50)
)

alter table kullanici 
add k_yetki tinyint;

create proc sp_kullanici_girisi
(
    @k_adi nvarchar(50),
	@k_sifresi nvarchar(50)
)
as
if not exists (select k_adi,k_sifre from kullanici where k_adi = @k_adi and k_sifre = @k_sifresi)
begin
select 'Giris Basarili!' as [Hata]
end
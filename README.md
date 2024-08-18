Bu projede, dört farklı alt proje (API, Core, Repository, Service) bulunmakta ve bu projeler ayrı modüller halinde yapılandırılmıştır.

API: Bu katman, kullanıcıların etkileşimde bulunabileceği web arayüzünü sağlar. API projesi, dış dünyaya veri ve işlevsellik sunar ve genellikle HTTP protokolleri üzerinden çeşitli istemcilerle haberleşir.

Core: Bu proje, iş mantığının ve veri modellerinin yer aldığı temel bileşendir. İş kuralları, doğrulamalar, veri transfer objeleri gibi unsurlar bu katmanda yer alır. Diğer projeler, Core katmanındaki iş mantığına dayanır.

Repository: Bu katman, veri erişim işlemlerinin gerçekleştirildiği projedir. Veritabanı işlemleri ve veri saklama işlemleri Repository projesi aracılığıyla gerçekleştirilir. Entity Framework veya başka bir ORM kullanılabilir.

Service: İş mantığını soyutlayan ve API'nin ihtiyaç duyduğu işlevsellikleri sağlayan servis katmanıdır. Bu katman, Core katmanı ile API katmanı arasında köprü görevi görür. API isteklerini karşılar ve Repository katmanıyla veri alışverişi yapar.

Bu yapı, projeyi daha modüler ve genişletilebilir hale getirmek için DDD (Domain-Driven Design) ve SOLID prensipleri göz önünde bulundurularak tasarlanmıştır.

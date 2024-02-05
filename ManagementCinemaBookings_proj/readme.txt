
                                                                                                                                     PROJECT "MANAGEMENT OF CINEMA BOOKINGS" 

Projekat "Management of Cinema Bookings" ili "Upravljanje kino rezervacijama" predstavlja C# projekat baziran na MVC paternu.
Namjena ovog projekta je predviđena za dinamičan proces funkcionisanja prodaje (rezervacije) kino ulaznica klijentima. 
Definisane tabele baze podataka "Management Cinema Bookings" su:
     1. Table CinemaHalls (Tabela kino dvorane)
     2. Table CinemaMovies (Tabela kino filmovi)
     3. Table CinemaScreenings (Tabela kino projekcije)
     4. Table CinemaEmployeeTypes (Tabela tipovi kino zaposlenika)
     5. Table CinemaEmployees (Tabela kino zaposlenici)
     6. Table CinemaTicketBookings (Tabela rezervacije kino ulaznica) 
Sve ove tabele (objekti) baze podataka su mapirane u njima odgovarajuće klase entitetskog modela podataka tako da te klase nose naziv po tipu modela podataka enitetske klase.


                                                                                                                SPECIFIČNOSTI PROJEKTA "UPRAVLJANJE KINO REZERVACIJAMA"

C# projekat "Upravljanje kino rezervacijama" posjeduje formu za prijavu (logovanje) zaposlenika kina.
Nakon uspješnog logovanja zaposlenika tipa administrator automatski se otvara stranica za prikaz liste kino zaposlenika.
Nakon uspješnog logovanja zaposlenika tipa korisnik automatski se otvara stranica za prikaz liste prodanih kino ulaznica.
Prilikom prijave administratora u navigacionom dijelu stranice dostupni su mu sljedeći linkovi:
     1. Link za prikazivanje liste kino dvorana 
     2. Link za prikazivaje liste kino filmova
     3. Link za prikazivanje liste kino projekcija
     4. Link za prikazivanje liste kino zaposlenika
     5. Link za prikazivanje liste rezervisanih (prodanih) kino ulaznica
     6. Link za odjavu na stranicu za prijavu (logovanje) kino zaposlenika 
Prilikom prijave korisnika u navigacionom dijelu stranice dostupni su mu sljedeći linkovi:
     1. Link za prikazivanje liste kino dvorana
     2. Link za prikazivaje liste kino filmova
     3. Link za prikazivanje liste kino projekcija
     4. Link za prikazivanje liste rezervisanih (prodanih) kino ulaznica
     5. Link za odjavu na stranicu za prijavu (logovanje) kino zaposlenika 
Dodatno, u navigacionom dijelu stranice na lijevoj strani nalazi se naziv ulogovanog zaposlenika (administrator ili korisnik) koji se pojavljuje na navedenom mjestu nakon uspješne prijave zaposlenika.
Ovaj C# projekat pored stranice za prikaz liste kino dvorana sadrži:
     1. Stranicu za prikaz forme koja izvršava rezervaciju kino dvorana
     2. Stranicu za prikaz forme koja izvršava ažuriranje (promjenu) kino dvorana     
Projekat pored stranice za prikaz liste kino filmova sadrži:
     1. Stranicu za prikaz forme koja izvršava registraciju kino filmova
     2. Stranicu za prikaz forme čija je svrha ažuriranje (promjena) kino filmova
     3. Stranicu za prikaz forme čija je svrha uklanjanje postojećih kino filmova
Pored stranice za prikaz liste kino projekcija projekat sadrži:
     1. Stranicu za prikaz forme koja izvršava rezervaciju kino projekcija
     2. Stranicu za prikaz forme čija je svrha ažuriranje (promjena) kino projekcija
Pored stranice za prikaz liste kino zaposlenika projekat sadrži:
     1. Stranicu za prikaz forme koja izvršava registraciju kino zaposlenika
     2. Stranicu za prikaz forme čija je svrha ažuriranje (promjena) kino zaposlenika
     3. Stranicu za prikaz forme čija je svrha uklanjanje postojećih kino zaposlenika 
Projekat pored stranice za prikaz liste prodanih kino ulaznica sadrži:
     1. Stranicu za prikaz forme koja izvršava rezervaciju (prodaju) kino ulaznica  
Ovaj projekat je baziran na definisanju sprječavanja (prevencije) pristupa svim stranicama bez prethodne prijave (logovanja) zaposlenika (administrator ili korisnik) tj. pristup ovim stranicama je strogo uvjetovan (ispravnom) prijavom na stranici za logovanje zaposlenika.
Posjeduje i definisanu enkripciju šifri (passwords) svih kino zaposlenika u bazi podataka u cilju zaštite povjerljivosti podataka.
 
 









 
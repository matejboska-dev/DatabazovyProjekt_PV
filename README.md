
# PV_DatabaseProject_MatejBoska

Úvod
Tento projekt slouží k vytvoření a správě databáze pro podnikový systém, který eviduje informace o zákaznících, produktech, objednávkách a dalších entitách. Databáze je navržena v programovacím jazyce C# s využitím přístupu k relační databázi pomocí technologie ADO.NET. Projekt je rozdělen do několika tříd, které zajišťují práci s jednotlivými tabulkami v databázi.

Změny ve třídě DatabaseSingleton
V třídě DatabaseSingleton byly provedeny některé úpravy k lepší správě prostředků a zacházení s chybami. Přidán byl zámek pro zajištění bezpečné práce s připojením ve vícevláknovém prostředí. Byla přidána kontrola stavu připojení před pokusem otevřít nové připojení. Tím se minimalizuje riziko chybného chování při opakovaném otevírání nebo při pokusu otevřít již zavřené připojení. Kód třídy byl také reorganizován pro lepší čitelnost.

Třídy DAO (Data Access Object)
V projektu jsou implementovány třídy DAO pro každou entitu v databázi. Třídy DAO (např. CustomerDAO, ProductDAO) zajišťují komunikaci mezi objekty v programu a databází. Každá třída obsahuje metody pro načítání, ukládání, mazání a aktualizaci záznamů v příslušné tabulce. Tyto třídy implementují rozhraní IDAO<T>, kde T je typ odpovídající tabulce.

Struktura Tabulek:
Customers (Zákazníci):
customer_id - jednoznačný identifikátor zákazníka
first_name - křestní jméno zákazníka
last_name - příjmení zákazníka
email - e-mailová adresa zákazníka
phone_number - telefonní číslo zákazníka

Products (Produkty):
product_id - jednoznačný identifikátor produktu
product_name - název produktu
price - cena produktu
stock_quantity - skladové množství produktu
category_id - identifikátor kategorie produktu, cizí klíč odkazující na tabulku ProductCategories

Orders (Objednávky):
order_id - jednoznačný identifikátor objednávky
customer_id - identifikátor zákazníka, cizí klíč odkazující na tabulku Customers
order_date - datum vytvoření objednávky

OrderItems (Položky Objednávky):
order_item_id - jednoznačný identifikátor položky objednávky
order_id - identifikátor objednávky, cizí klíč odkazující na tabulku Orders
product_id - identifikátor produktu, cizí klíč odkazující na tabulku Products
quantity - množství zakoupeného produktu
total_price - celková cena položky objednávky

ProductCategories (Kategorie Produktů):
category_id - jednoznačný identifikátor kategorie produktu
category_name - název kategorie produktu
Proč Používáme DAOs a Singleton
Použití tříd DAO (Data Access Object) usnadňuje oddělení logiky pracující s databází od logiky aplikační vrstvy. Třídy DAO poskytují jednotné rozhraní pro manipulaci s entitami v databázi.

Singleton nám umožňuje vytvořit jedinou instanci připojení k databázi, kterou lze sdílet napříč celou aplikací. Tím snižujeme režii spojenou s vytvářením nových připojení a zajišťujeme konzistenci a správnou správu připojení.

Jak Spustit Projekt
Naklonujte repozitář na svůj lokální stroj.
Otevřete projekt v prostředí Visual Studio nebo jiném vhodném vývojovém prostředí pro jazyk C#.
Změňte připojení k databázi v třídě DatabaseSingleton dle vašich potřeb.
Spusťte projekt a pracujte s ním podle vašich požadavků.
Pokud narazíte na problémy nebo máte otázky, neváhejte se zeptat.

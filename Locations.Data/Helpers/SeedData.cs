using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Locations.Data.Helpers
{
    public static class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new LocationsContext(serviceProvider.GetRequiredService<DbContextOptions<LocationsContext>>()))
            {
                // Check if any locations exist
                if (context.Locations.Any())
                {
                    return; // Database already populated
                }

                context.Locations.AddRange(
                    new Location { Name = "Vivian St, Blackburn", Address = "4 Vivian St", City = "Blackburn", County = "Lancashire", PostCode = "BB2 6LB", Phone = "01379-603039", Latitude = 53.752578, Longitude = -2.506155, Type = LocationType.TownStore },
                    new Location { Name = "Aigburth St, Blackburn", Address = "404 Aigburth St", City = "Blackburn", County = "Lancashire", PostCode = "BB1 2AA", Phone = "01559-323337", Latitude = 53.74901, Longitude = -2.456874, Type = LocationType.Local },
                    new Location { Name = "Pall Mall, Blackpool", Address = "603 Pall Mall", City = "Blackpool", County = "Lancashire", PostCode = "FY3 8ND", Phone = "01694-424205", Latitude = 53.822536, Longitude = -3.01874, Type = LocationType.Local },
                    new Location { Name = "Grayson St, Blackpool", Address = "162 Grayson St", City = "Blackpool", County = "Lancashire", PostCode = "FY2 0TD", Phone = "01624-595660", Latitude = 53.838854, Longitude = -3.031963, Type = LocationType.Local },
                    new Location { Name = "Britton St, Bolton", Address = "6766 Britton St", City = "Bolton", County = "Greater Manchester", PostCode = "BL1 3EX", Phone = "01912-749219", Latitude = 53.59237, Longitude = -2.450272, Type = LocationType.Megastore },
                    new Location { Name = "Sussex St, Bolton", Address = "123 Sussex St", City = "Bolton", County = "Greater Manchester", PostCode = "BL1 6PY", Phone = "01457-837447", Latitude = 53.598733, Longitude = -2.44079, Type = LocationType.TownStore },
                    new Location { Name = "Gloucester Pl, Bolton", Address = "2395 Gloucester Pl", City = "Bolton", County = "Greater Manchester", PostCode = "BL1 6DS", Phone = "01368-497445", Latitude = 53.588641, Longitude = -2.452558, Type = LocationType.TownStore },
                    new Location { Name = "Nesfield St, Bolton", Address = "1111 Nesfield St", City = "Bolton", County = "Greater Manchester", PostCode = "BL2 2SU", Phone = "01620-435994", Latitude = 53.581686, Longitude = -2.404196, Type = LocationType.TownStore },
                    new Location { Name = "Clark St, Bolton", Address = "143 Clark St", City = "Bolton", County = "Greater Manchester", PostCode = "BL1 2PS", Phone = "01934-672498", Latitude = 53.583387, Longitude = -2.436702, Type = LocationType.Megastore },
                    new Location { Name = "Thomaston St, Bolton", Address = "8 Thomaston St", City = "Bolton", County = "Greater Manchester", PostCode = "BL1 8RG", Phone = "01818-292728", Latitude = 53.604071, Longitude = -2.42877, Type = LocationType.Megastore },
                    new Location { Name = "Covent Garden, Bolton", Address = "4 Covent Garden", City = "Bolton", County = "Greater Manchester", PostCode = "BL4 7AF", Phone = "01333-436799", Latitude = 53.548666, Longitude = -2.395293, Type = LocationType.TownStore },
                    new Location { Name = "Greig St, Bury", Address = "1175 Greig St", City = "Bury", County = "Greater Manchester", PostCode = "M25 0ZN", Phone = "01532-497454", Latitude = 53.53444, Longitude = -2.287119, Type = LocationType.TownStore },
                    new Location { Name = "Denison St, Bury", Address = "82 Denison St", City = "Bury", County = "Greater Manchester", PostCode = "M25 1JB", Phone = "01699-467608", Latitude = 53.531421, Longitude = -2.267321, Type = LocationType.Megastore },
                    new Location { Name = "Pine St, Bury", Address = "79 Pine St", City = "Bury", County = "Greater Manchester", PostCode = "M26 1GH", Phone = "01585-487560", Latitude = 53.552484, Longitude = -2.314139, Type = LocationType.Local },
                    new Location { Name = "Britannia Ave, Fylde", Address = "7 Britannia Ave", City = "Fylde", County = "Lancashire", PostCode = "PR4 3RQ", Phone = "01911-775929", Latitude = 53.771774, Longitude = -2.842142, Type = LocationType.Local },
                    new Location { Name = "Haddock St, Fylde", Address = "7 Haddock St", City = "Fylde", County = "Lancashire", PostCode = "FY8 3TF", Phone = "01574-363346", Latitude = 53.753436, Longitude = -3.008877, Type = LocationType.TownStore },
                    new Location { Name = "Toxteth St, Hyndburn", Address = "2577 Toxteth St", City = "Hyndburn", County = "Lancashire", PostCode = "BB6 7UN", Phone = "01527-579687", Latitude = 53.798938, Longitude = -2.410003, Type = LocationType.Megastore },
                    new Location { Name = "Curzon St, Hyndburn", Address = "4679 Curzon St", City = "Hyndburn", County = "Lancashire", PostCode = "BB5 0SJ", Phone = "01354-864473", Latitude = 53.748576, Longitude = -2.374968, Type = LocationType.Megastore },
                    new Location { Name = "Howe St, Hyndburn", Address = "883 Howe St", City = "Hyndburn", County = "Lancashire", PostCode = "BB5 5TJ", Phone = "01790-887225", Latitude = 53.779748, Longitude = -2.3886, Type = LocationType.Megastore },
                    new Location { Name = "Lister Rd, Hyndburn", Address = "115 Lister Rd", City = "Hyndburn", County = "Lancashire", PostCode = "BB5 2EY", Phone = "01616-548910", Latitude = 53.749685, Longitude = -2.36503, Type = LocationType.Local },
                    new Location { Name = "Sidney Rd, Knowsley", Address = "3833 Sidney Rd", City = "Knowsley", County = "Merseyside", PostCode = "L32 3XS", Phone = "01378-845450", Latitude = 53.468899, Longitude = -2.885106, Type = LocationType.Megastore },
                    new Location { Name = "Regent St, Lancaster", Address = "94 Regent St", City = "Lancaster", County = "Lancashire", PostCode = "LA6 1DB", Phone = "01478-392232", Latitude = 54.123698, Longitude = -2.731124, Type = LocationType.Megastore },
                    new Location { Name = "Newlands St, Liverpool", Address = "97 Newlands St", City = "Liverpool", County = "Merseyside", PostCode = "L6 9DU", Phone = "01544-247601", Latitude = 53.417659, Longitude = -2.951391, Type = LocationType.Megastore },
                    new Location { Name = "Christopher St, Liverpool", Address = "1554 Christopher St", City = "Liverpool", County = "Merseyside", PostCode = "L6 1BG", Phone = "01976-784016", Latitude = 53.415831, Longitude = -2.965193, Type = LocationType.Local },
                    new Location { Name = "Ledward St, Liverpool", Address = "7642 Ledward St", City = "Liverpool", County = "Merseyside", PostCode = "L19 0LN", Phone = "01919-185409", Latitude = 53.360775, Longitude = -2.918372, Type = LocationType.Local },
                    new Location { Name = "Sherwood St, Liverpool", Address = "4 Sherwood St", City = "Liverpool", County = "Merseyside", PostCode = "L24 6SH", Phone = "01708-724957", Latitude = 53.34501, Longitude = -2.82199, Type = LocationType.TownStore },
                    new Location { Name = "Blantyre Rd, Liverpool", Address = "236 Blantyre Rd", City = "Liverpool", County = "Merseyside", PostCode = "L6 2EN", Phone = "01982-734773", Latitude = 53.415886, Longitude = -2.96402, Type = LocationType.TownStore },
                    new Location { Name = "Ogwen St, Manchester", Address = "9548 Ogwen St", City = "Manchester", County = "Greater Manchester", PostCode = "M23 9GB", Phone = "01740-739731", Latitude = 53.391555, Longitude = -2.296035, Type = LocationType.Megastore },
                    new Location { Name = "Medlock St, Manchester", Address = "74 Medlock St", City = "Manchester", County = "Greater Manchester", PostCode = "M20 1JG", Phone = "01203-684728", Latitude = 53.428648, Longitude = -2.241527, Type = LocationType.TownStore },
                    new Location { Name = "Edge Grove, Manchester", Address = "7217 Edge Grove", City = "Manchester", County = "Greater Manchester", PostCode = "M22 4ZB", Phone = "01750-379103", Latitude = 53.391563, Longitude = -2.253767, Type = LocationType.TownStore },
                    new Location { Name = "Townsend St, Oldham", Address = "50 Townsend St", City = "Oldham", County = "Greater Manchester", PostCode = "OL9 0NS", Phone = "01641-726098", Latitude = 53.549016, Longitude = -2.165723, Type = LocationType.Megastore },
                    new Location { Name = "Chestnut St, Pendle", Address = "8 Chestnut St", City = "Pendle", County = "Lancashire", PostCode = "BB9 6EW", Phone = "01918-999052", Latitude = 53.852294, Longitude = -2.21558, Type = LocationType.Megastore },
                    new Location { Name = "Clyde Rd, Preston", Address = "93 Clyde Rd", City = "Preston", County = "Lancashire", PostCode = "PR1 6TN", Phone = "01311-567052", Latitude = 53.769736, Longitude = -2.688363, Type = LocationType.TownStore },
                    new Location { Name = "Hey Green Rd, Preston", Address = "42 Hey Green Rd", City = "Preston", County = "Lancashire", PostCode = "PR1 6TL", Phone = "01752-399931", Latitude = 53.768965, Longitude = -2.688002, Type = LocationType.TownStore },
                    new Location { Name = "Eldon Place, Burnley", Address = "87 Eldon Place", City = "Burnley", County = "Lancashire", PostCode = "BB12 7RY", Phone = "01315-409372", Latitude = 53.813173, Longitude = -2.364732, Type = LocationType.Local },
                    new Location { Name = "Mason St, Rochdale", Address = "77 Mason St", City = "Rochdale", County = "Greater Manchester", PostCode = "OL16 3AW", Phone = "01224-605237", Latitude = 53.621381, Longitude = -2.126743, Type = LocationType.Local },
                    new Location { Name = "Westbank Rd, Rochdale", Address = "805 Westbank Rd", City = "Rochdale", County = "Greater Manchester", PostCode = "OL10 2DU", Phone = "01270-562265", Latitude = 53.587718, Longitude = -2.212342, Type = LocationType.TownStore },
                    new Location { Name = "Seacombe St, Rochdale", Address = "2 Seacombe St", City = "Rochdale", County = "Greater Manchester", PostCode = "OL15 0JP", Phone = "01919-731224", Latitude = 53.645434, Longitude = -2.088364, Type = LocationType.TownStore },
                    new Location { Name = "Great Howard St, Sefton", Address = "8880 Great Howard St", City = "Sefton", County = "Merseyside", PostCode = "L29 7WD", Phone = "01358-446391", Latitude = 53.509138, Longitude = -2.9869, Type = LocationType.TownStore },
                    new Location { Name = "Pyramid St, St. Helens", Address = "3 Pyramid St", City = "St. Helens", County = "Merseyside", PostCode = "WA10 3BW", Phone = "01546-942059", Latitude = 53.43894, Longitude = -2.775494, Type = LocationType.Local },
                    new Location { Name = "Upper Harrington St, St. Helens", Address = "999 Upper Harrington St", City = "St. Helens", County = "Merseyside", PostCode = "WA12 9WX", Phone = "01754-426672", Latitude = 53.459852, Longitude = -2.639752, Type = LocationType.Local },
                    new Location { Name = "Carlton St, St. Helens", Address = "159 Carlton St", City = "St. Helens", County = "Merseyside", PostCode = "WA10 6QG", Phone = "01481-744296", Latitude = 53.468386, Longitude = -2.751687, Type = LocationType.TownStore },
                    new Location { Name = "Jackson St, St. Helens", Address = "9 Jackson St", City = "St. Helens", County = "Merseyside", PostCode = "WA9 3QW", Phone = "01876-642683", Latitude = 53.445808, Longitude = -2.695068, Type = LocationType.TownStore },
                    new Location { Name = "Argyle St, Tameside", Address = "1 Argyle St", City = "Tameside", County = "Greater Manchester", PostCode = "SK14 5AR", Phone = "01934-427282", Latitude = 53.44061, Longitude = -2.085739, Type = LocationType.TownStore },
                    new Location { Name = "Gertrude St, Tameside", Address = "8 Gertrude St", City = "Tameside", County = "Greater Manchester", PostCode = "OL5 0QJ", Phone = "01348-989703", Latitude = 53.522436, Longitude = -2.044472, Type = LocationType.Megastore },
                    new Location { Name = "Saxon St, Trafford", Address = "260 Saxon St", City = "Trafford", County = "Greater Manchester", PostCode = "M33 4BP", Phone = "01537-525550", Latitude = 53.415061, Longitude = -2.336595, Type = LocationType.TownStore },
                    new Location { Name = "Queens Rd, Trafford", Address = "792 Queens Rd", City = "Trafford", County = "Greater Manchester", PostCode = "M32 8LR", Phone = "01526-145485", Latitude = 53.444729, Longitude = -2.307727, Type = LocationType.Local },
                    new Location { Name = "Pallas St, Trafford", Address = "328 Pallas St", City = "Trafford", County = "Greater Manchester", PostCode = "M32 8LJ", Phone = "01619-237602", Latitude = 53.448859, Longitude = -2.302397, Type = LocationType.TownStore },
                    new Location { Name = "Picton Rd, Wigan", Address = "553 Picton Rd", City = "Wigan", County = "Greater Manchester", PostCode = "M29 7AA", Phone = "01274-659801", Latitude = 53.500936, Longitude = -2.46088, Type = LocationType.Megastore },
                    new Location { Name = "Hampden St, Wirral", Address = "5 Hampden St", City = "Wirral", County = "Merseyside", PostCode = "CH45 4RN", Phone = "01467-142439", Latitude = 53.419971, Longitude = -3.049823, Type = LocationType.Local },
                    new Location { Name = "Wellington Rd, Wyre", Address = "493 Wellington Rd", City = "Wyre", County = "Lancashire", PostCode = "PR3 0UH", Phone = "01772-461124", Latitude = 53.864727, Longitude = -2.852797, Type = LocationType.TownStore },
                    new Location { Name = "Marine Parade, Wyre", Address = "30 Marine Parade", City = "Wyre", County = "Lancashire", PostCode = "FY5 4FN", Phone = "01994-675650", Latitude = 53.876462, Longitude = -2.999973, Type = LocationType.TownStore });

                foreach (var location in context.Locations.Local.ToList())
                {
                    foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                    {
                        var openingHour = new OpeningHour { Location = location, DayOfWeek = day };

                        switch (location.Type)
                        {
                            case LocationType.Local:
                                openingHour.Opening = 6;
                                openingHour.Closing = 22;
                                break;
                            case LocationType.Megastore:
                                switch (day)
                                {
                                    case DayOfWeek.Sunday:
                                        openingHour.Opening = 10;
                                        openingHour.Closing = 16;
                                        break;
                                    default:
                                        openingHour.Opening = 6;
                                        openingHour.Closing = 24;
                                        break;
                                }
                                break;
                            case LocationType.TownStore:
                                switch (day)
                                {
                                    case DayOfWeek.Sunday:
                                        openingHour.Opening = 10;
                                        openingHour.Closing = 16;
                                        break;
                                    default:
                                        openingHour.Opening = 6;
                                        openingHour.Closing = 22;
                                        break;
                                }
                                break;
                            default:
                                break;
                        }

                        context.OpeningHours.Add(openingHour);                        
                    }                    
                }

                context.SaveChanges();
            }
        }
    }
}
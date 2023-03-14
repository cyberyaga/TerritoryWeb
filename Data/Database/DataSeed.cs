using Microsoft.EntityFrameworkCore;
using TerritoryWeb.Data.Models;

namespace TerritoryWeb.Data.Database;

public class DataSeed
{
    public static ModelBuilder modelBuilderSeed(ModelBuilder modelBuilder)
    {
                //seed data
        modelBuilder.Entity<Congregation>().HasData(new Congregation[] {
                new Congregation { Id = 1, Description = "Cedar Crest Spanish" }
            });

        modelBuilder.Entity<PublisherType>().HasData(new PublisherType[] {
                new PublisherType { Id = 1, Description = "Publisher" },
                new PublisherType { Id = 2, Description = "Pioneer" },
                new PublisherType { Id = 3, Description = "Elder" }
            });

        modelBuilder.Entity<TerritoryType>().HasData(new TerritoryType[] {
                new TerritoryType { Id = 1, Description = "Door to Door" },
                new TerritoryType { Id = 2, Description = "Telephone" }
            });

        modelBuilder.Entity<DoorCode>().HasData(new DoorCode[] {
            new DoorCode{ Id = 1, CongregationID = 1, Description = "Expulsado"},
            new DoorCode{ Id = 2, CongregationID = 1, Description = "Peligroso"},
            new DoorCode{ Id = 3, CongregationID = 1, Description = "No Visitar"},
            new DoorCode{ Id = 4, CongregationID = 1, Description = "Privado"},
            new DoorCode{ Id = 5, CongregationID = 1, Description = "Vacio"},
            new DoorCode{ Id = 6, CongregationID = 1, Description = "Negocio"},
            new DoorCode{ Id = 7, CongregationID = 1, Description = "No desean cartas"}
        });

        // Set up the relationship between DoorCode and Congregation
        modelBuilder.Entity<DoorCode>()
            .HasOne(dc => dc.Congregation)
            .WithMany(c => c.DoorCodes)
            .HasForeignKey(dc => dc.CongregationID);

        modelBuilder.Entity<Language>().HasData(new Language[] {
                new Language { Id = 1, Description = "English" },
                new Language { Id = 2, Description = "Español" }
            });

        modelBuilder.Entity<Territory>().HasData(new Territory[] {
                new Territory {
                    Id = 1,
                    TerritoryName = "Allentown - 01",
                    TerritoryTypeID = 1,
                    CongregationID = 1,
                    Added = DateTime.Now,
                    AddedBy = "cyberyaga@hotmail.com",
                    Modified = DateTime.Now,
                    ModifiedBy = "cyberyaga@hotmail.com"
                }
            });

        modelBuilder.Entity<Door>().HasData(new Door[] {
                new Door {
                    Id = 2,
                    TerritoryID = 1,
                    Address = "1526",
                    Street = "Catalina Ave.",
                    PostalCode = "18103",
                    Comments = "Test comment",
                    Name = "Cesar Rodriguez",
                    Telephone = "212-555-1212",
                    GeoLat = 40.578639M,
                    GeoLong = -75.481580M,
                    AddedBy = "cyberyaga@hotmail.com",
                    Added = DateTime.Now,
                    ModifiedBy = "cyberyaga@hotmail.com",
                    Modified = DateTime.Now,
                    DoorCodeID = null
                }
            });

        modelBuilder.Entity<TerritoryBound>().HasData(new TerritoryBound[] {
                new TerritoryBound { BoundaryID = 2430, TerritoryID = 1, GeoLat = 40.584240M, GeoLong = -75.503010M },
                new TerritoryBound { BoundaryID = 2431, TerritoryID = 1, GeoLat = 40.579930M, GeoLong = -75.502500M },
                new TerritoryBound { BoundaryID = 2432, TerritoryID = 1, GeoLat = 40.578870M, GeoLong = -75.502400M },
                new TerritoryBound { BoundaryID = 2433, TerritoryID = 1, GeoLat = 40.577780M, GeoLong = -75.502280M },
                new TerritoryBound { BoundaryID = 2434, TerritoryID = 1, GeoLat = 40.577100M, GeoLong = -75.502200M },
                new TerritoryBound { BoundaryID = 2435, TerritoryID = 1, GeoLat = 40.576790M, GeoLong = -75.502170M },
                new TerritoryBound { BoundaryID = 2436, TerritoryID = 1, GeoLat = 40.576520M, GeoLong = -75.502080M },
                new TerritoryBound { BoundaryID = 2437, TerritoryID = 1, GeoLat = 40.576260M, GeoLong = -75.501960M },
                new TerritoryBound { BoundaryID = 2438, TerritoryID = 1, GeoLat = 40.575890M, GeoLong = -75.501690M },
                new TerritoryBound { BoundaryID = 2439, TerritoryID = 1, GeoLat = 40.575550M, GeoLong = -75.501410M },
                new TerritoryBound { BoundaryID = 2440, TerritoryID = 1, GeoLat = 40.575070M, GeoLong = -75.501010M },
                new TerritoryBound { BoundaryID = 2441, TerritoryID = 1, GeoLat = 40.574470M, GeoLong = -75.500530M },
                new TerritoryBound { BoundaryID = 2442, TerritoryID = 1, GeoLat = 40.574220M, GeoLong = -75.500240M },
                new TerritoryBound { BoundaryID = 2443, TerritoryID = 1, GeoLat = 40.574080M, GeoLong = -75.500020M },
                new TerritoryBound { BoundaryID = 2444, TerritoryID = 1, GeoLat = 40.573890M, GeoLong = -75.499710M },
                new TerritoryBound { BoundaryID = 2445, TerritoryID = 1, GeoLat = 40.573600M, GeoLong = -75.499350M },
                new TerritoryBound { BoundaryID = 2446, TerritoryID = 1, GeoLat = 40.573350M, GeoLong = -75.499170M },
                new TerritoryBound { BoundaryID = 2447, TerritoryID = 1, GeoLat = 40.573070M, GeoLong = -75.499030M },
                new TerritoryBound { BoundaryID = 2448, TerritoryID = 1, GeoLat = 40.572670M, GeoLong = -75.498960M },
                new TerritoryBound { BoundaryID = 2449, TerritoryID = 1, GeoLat = 40.572510M, GeoLong = -75.498980M },
                new TerritoryBound { BoundaryID = 2450, TerritoryID = 1, GeoLat = 40.572370M, GeoLong = -75.499000M },
                new TerritoryBound { BoundaryID = 2451, TerritoryID = 1, GeoLat = 40.571590M, GeoLong = -75.499210M },
                new TerritoryBound { BoundaryID = 2452, TerritoryID = 1, GeoLat = 40.571050M, GeoLong = -75.499350M },
                new TerritoryBound { BoundaryID = 2453, TerritoryID = 1, GeoLat = 40.570610M, GeoLong = -75.499450M },
                new TerritoryBound { BoundaryID = 2454, TerritoryID = 1, GeoLat = 40.570320M, GeoLong = -75.499470M },
                new TerritoryBound { BoundaryID = 2455, TerritoryID = 1, GeoLat = 40.570070M, GeoLong = -75.499470M },
                new TerritoryBound { BoundaryID = 2456, TerritoryID = 1, GeoLat = 40.569860M, GeoLong = -75.499460M },
                new TerritoryBound { BoundaryID = 2457, TerritoryID = 1, GeoLat = 40.569500M, GeoLong = -75.499390M },
                new TerritoryBound { BoundaryID = 2458, TerritoryID = 1, GeoLat = 40.569210M, GeoLong = -75.499300M },
                new TerritoryBound { BoundaryID = 2459, TerritoryID = 1, GeoLat = 40.568420M, GeoLong = -75.498920M },
                new TerritoryBound { BoundaryID = 2460, TerritoryID = 1, GeoLat = 40.567320M, GeoLong = -75.498280M },
                new TerritoryBound { BoundaryID = 2461, TerritoryID = 1, GeoLat = 40.566620M, GeoLong = -75.497890M },
                new TerritoryBound { BoundaryID = 2462, TerritoryID = 1, GeoLat = 40.565930M, GeoLong = -75.497500M },
                new TerritoryBound { BoundaryID = 2463, TerritoryID = 1, GeoLat = 40.564660M, GeoLong = -75.484860M },
                new TerritoryBound { BoundaryID = 2464, TerritoryID = 1, GeoLat = 40.571450M, GeoLong = -75.481290M },
                new TerritoryBound { BoundaryID = 2465, TerritoryID = 1, GeoLat = 40.571880M, GeoLong = -75.481070M },
                new TerritoryBound { BoundaryID = 2466, TerritoryID = 1, GeoLat = 40.572390M, GeoLong = -75.480890M },
                new TerritoryBound { BoundaryID = 2467, TerritoryID = 1, GeoLat = 40.572760M, GeoLong = -75.480830M },
                new TerritoryBound { BoundaryID = 2468, TerritoryID = 1, GeoLat = 40.574330M, GeoLong = -75.480820M },
                new TerritoryBound { BoundaryID = 2469, TerritoryID = 1, GeoLat = 40.575870M, GeoLong = -75.480840M },
                new TerritoryBound { BoundaryID = 2470, TerritoryID = 1, GeoLat = 40.577110M, GeoLong = -75.480830M },
                new TerritoryBound { BoundaryID = 2471, TerritoryID = 1, GeoLat = 40.577620M, GeoLong = -75.480820M },
                new TerritoryBound { BoundaryID = 2472, TerritoryID = 1, GeoLat = 40.578170M, GeoLong = -75.480810M },
                new TerritoryBound { BoundaryID = 2473, TerritoryID = 1, GeoLat = 40.578670M, GeoLong = -75.480700M },
                new TerritoryBound { BoundaryID = 2474, TerritoryID = 1, GeoLat = 40.578800M, GeoLong = -75.480670M },
                new TerritoryBound { BoundaryID = 2475, TerritoryID = 1, GeoLat = 40.578910M, GeoLong = -75.480610M },
                new TerritoryBound { BoundaryID = 2476, TerritoryID = 1, GeoLat = 40.579130M, GeoLong = -75.480510M },
                new TerritoryBound { BoundaryID = 2477, TerritoryID = 1, GeoLat = 40.579340M, GeoLong = -75.480420M },
                new TerritoryBound { BoundaryID = 2478, TerritoryID = 1, GeoLat = 40.579570M, GeoLong = -75.480310M },
                new TerritoryBound { BoundaryID = 2479, TerritoryID = 1, GeoLat = 40.579910M, GeoLong = -75.480080M },
                new TerritoryBound { BoundaryID = 2480, TerritoryID = 1, GeoLat = 40.580170M, GeoLong = -75.479850M },
                new TerritoryBound { BoundaryID = 2481, TerritoryID = 1, GeoLat = 40.580360M, GeoLong = -75.479640M },
                new TerritoryBound { BoundaryID = 2482, TerritoryID = 1, GeoLat = 40.580410M, GeoLong = -75.479590M },
                new TerritoryBound { BoundaryID = 2483, TerritoryID = 1, GeoLat = 40.580550M, GeoLong = -75.479430M },
                new TerritoryBound { BoundaryID = 2484, TerritoryID = 1, GeoLat = 40.580630M, GeoLong = -75.479350M },
                new TerritoryBound { BoundaryID = 2485, TerritoryID = 1, GeoLat = 40.580700M, GeoLong = -75.479260M },
                new TerritoryBound { BoundaryID = 2486, TerritoryID = 1, GeoLat = 40.580860M, GeoLong = -75.479100M },
                new TerritoryBound { BoundaryID = 2487, TerritoryID = 1, GeoLat = 40.581040M, GeoLong = -75.478900M },
                new TerritoryBound { BoundaryID = 2488, TerritoryID = 1, GeoLat = 40.581130M, GeoLong = -75.478800M },
                new TerritoryBound { BoundaryID = 2489, TerritoryID = 1, GeoLat = 40.581270M, GeoLong = -75.478650M },
                new TerritoryBound { BoundaryID = 2490, TerritoryID = 1, GeoLat = 40.581410M, GeoLong = -75.478490M },
                new TerritoryBound { BoundaryID = 2491, TerritoryID = 1, GeoLat = 40.581550M, GeoLong = -75.478340M },
                new TerritoryBound { BoundaryID = 2492, TerritoryID = 1, GeoLat = 40.581600M, GeoLong = -75.478290M },
                new TerritoryBound { BoundaryID = 2493, TerritoryID = 1, GeoLat = 40.581750M, GeoLong = -75.478120M },
                new TerritoryBound { BoundaryID = 2494, TerritoryID = 1, GeoLat = 40.581790M, GeoLong = -75.478070M },
                new TerritoryBound { BoundaryID = 2495, TerritoryID = 1, GeoLat = 40.581830M, GeoLong = -75.478030M },
                new TerritoryBound { BoundaryID = 2496, TerritoryID = 1, GeoLat = 40.581870M, GeoLong = -75.477980M },
                new TerritoryBound { BoundaryID = 2497, TerritoryID = 1, GeoLat = 40.581920M, GeoLong = -75.477940M },
                new TerritoryBound { BoundaryID = 2498, TerritoryID = 1, GeoLat = 40.581950M, GeoLong = -75.477900M },
                new TerritoryBound { BoundaryID = 2499, TerritoryID = 1, GeoLat = 40.581990M, GeoLong = -75.477850M },
                new TerritoryBound { BoundaryID = 2500, TerritoryID = 1, GeoLat = 40.582070M, GeoLong = -75.477770M },
                new TerritoryBound { BoundaryID = 2501, TerritoryID = 1, GeoLat = 40.582180M, GeoLong = -75.477650M },
                new TerritoryBound { BoundaryID = 2502, TerritoryID = 1, GeoLat = 40.582290M, GeoLong = -75.477520M },
                new TerritoryBound { BoundaryID = 2503, TerritoryID = 1, GeoLat = 40.582340M, GeoLong = -75.477610M },
                new TerritoryBound { BoundaryID = 2504, TerritoryID = 1, GeoLat = 40.582380M, GeoLong = -75.477680M },
                new TerritoryBound { BoundaryID = 2505, TerritoryID = 1, GeoLat = 40.582480M, GeoLong = -75.477840M },
                new TerritoryBound { BoundaryID = 2506, TerritoryID = 1, GeoLat = 40.582610M, GeoLong = -75.478030M },
                new TerritoryBound { BoundaryID = 2507, TerritoryID = 1, GeoLat = 40.582670M, GeoLong = -75.478110M },
                new TerritoryBound { BoundaryID = 2508, TerritoryID = 1, GeoLat = 40.582740M, GeoLong = -75.478200M },
                new TerritoryBound { BoundaryID = 2509, TerritoryID = 1, GeoLat = 40.582890M, GeoLong = -75.478340M },
                new TerritoryBound { BoundaryID = 2510, TerritoryID = 1, GeoLat = 40.583040M, GeoLong = -75.478470M },
                new TerritoryBound { BoundaryID = 2511, TerritoryID = 1, GeoLat = 40.583150M, GeoLong = -75.478550M },
                new TerritoryBound { BoundaryID = 2512, TerritoryID = 1, GeoLat = 40.583260M, GeoLong = -75.478630M },
                new TerritoryBound { BoundaryID = 2513, TerritoryID = 1, GeoLat = 40.583280M, GeoLong = -75.478650M },
                new TerritoryBound { BoundaryID = 2514, TerritoryID = 1, GeoLat = 40.583330M, GeoLong = -75.478740M },
                new TerritoryBound { BoundaryID = 2515, TerritoryID = 1, GeoLat = 40.583390M, GeoLong = -75.478820M },
                new TerritoryBound { BoundaryID = 2516, TerritoryID = 1, GeoLat = 40.583530M, GeoLong = -75.478800M },
                new TerritoryBound { BoundaryID = 2517, TerritoryID = 1, GeoLat = 40.583680M, GeoLong = -75.478780M },
                new TerritoryBound { BoundaryID = 2518, TerritoryID = 1, GeoLat = 40.583950M, GeoLong = -75.478740M },
                new TerritoryBound { BoundaryID = 2519, TerritoryID = 1, GeoLat = 40.584100M, GeoLong = -75.478740M },
                new TerritoryBound { BoundaryID = 2520, TerritoryID = 1, GeoLat = 40.584280M, GeoLong = -75.478750M },
                new TerritoryBound { BoundaryID = 2521, TerritoryID = 1, GeoLat = 40.584490M, GeoLong = -75.478780M },
                new TerritoryBound { BoundaryID = 2522, TerritoryID = 1, GeoLat = 40.584720M, GeoLong = -75.478830M },
                new TerritoryBound { BoundaryID = 2523, TerritoryID = 1, GeoLat = 40.585090M, GeoLong = -75.478880M },
                new TerritoryBound { BoundaryID = 2524, TerritoryID = 1, GeoLat = 40.585300M, GeoLong = -75.478910M },
                new TerritoryBound { BoundaryID = 2525, TerritoryID = 1, GeoLat = 40.585520M, GeoLong = -75.478940M },
                new TerritoryBound { BoundaryID = 2526, TerritoryID = 1, GeoLat = 40.585490M, GeoLong = -75.479060M },
                new TerritoryBound { BoundaryID = 2527, TerritoryID = 1, GeoLat = 40.585480M, GeoLong = -75.479190M },
                new TerritoryBound { BoundaryID = 2528, TerritoryID = 1, GeoLat = 40.585510M, GeoLong = -75.479260M },
                new TerritoryBound { BoundaryID = 2529, TerritoryID = 1, GeoLat = 40.585530M, GeoLong = -75.479300M },
                new TerritoryBound { BoundaryID = 2530, TerritoryID = 1, GeoLat = 40.585550M, GeoLong = -75.479350M },
                new TerritoryBound { BoundaryID = 2531, TerritoryID = 1, GeoLat = 40.585730M, GeoLong = -75.479610M },
                new TerritoryBound { BoundaryID = 2532, TerritoryID = 1, GeoLat = 40.585930M, GeoLong = -75.479910M },
                new TerritoryBound { BoundaryID = 2533, TerritoryID = 1, GeoLat = 40.586170M, GeoLong = -75.480270M },
                new TerritoryBound { BoundaryID = 2534, TerritoryID = 1, GeoLat = 40.586390M, GeoLong = -75.480600M },
                new TerritoryBound { BoundaryID = 2535, TerritoryID = 1, GeoLat = 40.586560M, GeoLong = -75.480860M },
                new TerritoryBound { BoundaryID = 2536, TerritoryID = 1, GeoLat = 40.586660M, GeoLong = -75.481010M },
                new TerritoryBound { BoundaryID = 2537, TerritoryID = 1, GeoLat = 40.586890M, GeoLong = -75.481380M },
                new TerritoryBound { BoundaryID = 2538, TerritoryID = 1, GeoLat = 40.587090M, GeoLong = -75.481670M },
                new TerritoryBound { BoundaryID = 2539, TerritoryID = 1, GeoLat = 40.587340M, GeoLong = -75.482060M },
                new TerritoryBound { BoundaryID = 2540, TerritoryID = 1, GeoLat = 40.587650M, GeoLong = -75.482540M },
                new TerritoryBound { BoundaryID = 2541, TerritoryID = 1, GeoLat = 40.587900M, GeoLong = -75.482910M },
                new TerritoryBound { BoundaryID = 2542, TerritoryID = 1, GeoLat = 40.588140M, GeoLong = -75.483270M },
                new TerritoryBound { BoundaryID = 2543, TerritoryID = 1, GeoLat = 40.588230M, GeoLong = -75.483380M },
                new TerritoryBound { BoundaryID = 2544, TerritoryID = 1, GeoLat = 40.588300M, GeoLong = -75.483500M },
                new TerritoryBound { BoundaryID = 2545, TerritoryID = 1, GeoLat = 40.588360M, GeoLong = -75.483600M },
                new TerritoryBound { BoundaryID = 2546, TerritoryID = 1, GeoLat = 40.588380M, GeoLong = -75.483660M },
                new TerritoryBound { BoundaryID = 2547, TerritoryID = 1, GeoLat = 40.588410M, GeoLong = -75.483720M },
                new TerritoryBound { BoundaryID = 2548, TerritoryID = 1, GeoLat = 40.588490M, GeoLong = -75.483990M },
                new TerritoryBound { BoundaryID = 2549, TerritoryID = 1, GeoLat = 40.588580M, GeoLong = -75.484400M },
                new TerritoryBound { BoundaryID = 2550, TerritoryID = 1, GeoLat = 40.588590M, GeoLong = -75.484890M },
                new TerritoryBound { BoundaryID = 2551, TerritoryID = 1, GeoLat = 40.588470M, GeoLong = -75.486060M },
                new TerritoryBound { BoundaryID = 2552, TerritoryID = 1, GeoLat = 40.588410M, GeoLong = -75.486710M },
                new TerritoryBound { BoundaryID = 2553, TerritoryID = 1, GeoLat = 40.588420M, GeoLong = -75.486980M },
                new TerritoryBound { BoundaryID = 2554, TerritoryID = 1, GeoLat = 40.588460M, GeoLong = -75.487240M },
                new TerritoryBound { BoundaryID = 2555, TerritoryID = 1, GeoLat = 40.588600M, GeoLong = -75.487560M },
                new TerritoryBound { BoundaryID = 2556, TerritoryID = 1, GeoLat = 40.588830M, GeoLong = -75.487770M },
                new TerritoryBound { BoundaryID = 2557, TerritoryID = 1, GeoLat = 40.589100M, GeoLong = -75.487880M },
                new TerritoryBound { BoundaryID = 2558, TerritoryID = 1, GeoLat = 40.589370M, GeoLong = -75.488030M },
                new TerritoryBound { BoundaryID = 2559, TerritoryID = 1, GeoLat = 40.589680M, GeoLong = -75.488160M },
                new TerritoryBound { BoundaryID = 2560, TerritoryID = 1, GeoLat = 40.590000M, GeoLong = -75.488330M },
                new TerritoryBound { BoundaryID = 2561, TerritoryID = 1, GeoLat = 40.589930M, GeoLong = -75.488530M },
                new TerritoryBound { BoundaryID = 2562, TerritoryID = 1, GeoLat = 40.589850M, GeoLong = -75.488720M },
                new TerritoryBound { BoundaryID = 2563, TerritoryID = 1, GeoLat = 40.589700M, GeoLong = -75.489040M },
                new TerritoryBound { BoundaryID = 2564, TerritoryID = 1, GeoLat = 40.589550M, GeoLong = -75.489350M },
                new TerritoryBound { BoundaryID = 2565, TerritoryID = 1, GeoLat = 40.589390M, GeoLong = -75.489680M },
                new TerritoryBound { BoundaryID = 2566, TerritoryID = 1, GeoLat = 40.589320M, GeoLong = -75.489840M },
                new TerritoryBound { BoundaryID = 2567, TerritoryID = 1, GeoLat = 40.589250M, GeoLong = -75.490010M },
                new TerritoryBound { BoundaryID = 2568, TerritoryID = 1, GeoLat = 40.589180M, GeoLong = -75.490250M },
                new TerritoryBound { BoundaryID = 2569, TerritoryID = 1, GeoLat = 40.589130M, GeoLong = -75.490480M },
                new TerritoryBound { BoundaryID = 2570, TerritoryID = 1, GeoLat = 40.589070M, GeoLong = -75.491090M },
                new TerritoryBound { BoundaryID = 2571, TerritoryID = 1, GeoLat = 40.589030M, GeoLong = -75.491450M },
                new TerritoryBound { BoundaryID = 2572, TerritoryID = 1, GeoLat = 40.588980M, GeoLong = -75.491910M },
                new TerritoryBound { BoundaryID = 2573, TerritoryID = 1, GeoLat = 40.588950M, GeoLong = -75.492100M },
                new TerritoryBound { BoundaryID = 2574, TerritoryID = 1, GeoLat = 40.588920M, GeoLong = -75.492300M },
                new TerritoryBound { BoundaryID = 2575, TerritoryID = 1, GeoLat = 40.588890M, GeoLong = -75.492490M },
                new TerritoryBound { BoundaryID = 2576, TerritoryID = 1, GeoLat = 40.588840M, GeoLong = -75.492680M },
                new TerritoryBound { BoundaryID = 2577, TerritoryID = 1, GeoLat = 40.588780M, GeoLong = -75.492890M },
                new TerritoryBound { BoundaryID = 2578, TerritoryID = 1, GeoLat = 40.588730M, GeoLong = -75.493030M },
                new TerritoryBound { BoundaryID = 2579, TerritoryID = 1, GeoLat = 40.588640M, GeoLong = -75.493260M },
                new TerritoryBound { BoundaryID = 2580, TerritoryID = 1, GeoLat = 40.588400M, GeoLong = -75.493770M },
                new TerritoryBound { BoundaryID = 2581, TerritoryID = 1, GeoLat = 40.588230M, GeoLong = -75.494110M },
                new TerritoryBound { BoundaryID = 2582, TerritoryID = 1, GeoLat = 40.588050M, GeoLong = -75.494480M },
                new TerritoryBound { BoundaryID = 2583, TerritoryID = 1, GeoLat = 40.587890M, GeoLong = -75.494800M },
                new TerritoryBound { BoundaryID = 2584, TerritoryID = 1, GeoLat = 40.587730M, GeoLong = -75.495120M },
                new TerritoryBound { BoundaryID = 2585, TerritoryID = 1, GeoLat = 40.587570M, GeoLong = -75.495400M },
                new TerritoryBound { BoundaryID = 2586, TerritoryID = 1, GeoLat = 40.587410M, GeoLong = -75.495660M },
                new TerritoryBound { BoundaryID = 2587, TerritoryID = 1, GeoLat = 40.587260M, GeoLong = -75.495870M },
                new TerritoryBound { BoundaryID = 2588, TerritoryID = 1, GeoLat = 40.587180M, GeoLong = -75.495990M },
                new TerritoryBound { BoundaryID = 2589, TerritoryID = 1, GeoLat = 40.587110M, GeoLong = -75.496110M },
                new TerritoryBound { BoundaryID = 2590, TerritoryID = 1, GeoLat = 40.587020M, GeoLong = -75.496310M },
                new TerritoryBound { BoundaryID = 2591, TerritoryID = 1, GeoLat = 40.586940M, GeoLong = -75.496510M },
                new TerritoryBound { BoundaryID = 2592, TerritoryID = 1, GeoLat = 40.586860M, GeoLong = -75.496770M },
                new TerritoryBound { BoundaryID = 2593, TerritoryID = 1, GeoLat = 40.586790M, GeoLong = -75.497000M },
                new TerritoryBound { BoundaryID = 2594, TerritoryID = 1, GeoLat = 40.586610M, GeoLong = -75.497600M },
                new TerritoryBound { BoundaryID = 2595, TerritoryID = 1, GeoLat = 40.586510M, GeoLong = -75.497890M },
                new TerritoryBound { BoundaryID = 2596, TerritoryID = 1, GeoLat = 40.586410M, GeoLong = -75.498210M },
                new TerritoryBound { BoundaryID = 2597, TerritoryID = 1, GeoLat = 40.586280M, GeoLong = -75.498650M },
                new TerritoryBound { BoundaryID = 2598, TerritoryID = 1, GeoLat = 40.586190M, GeoLong = -75.498890M },
                new TerritoryBound { BoundaryID = 2599, TerritoryID = 1, GeoLat = 40.586060M, GeoLong = -75.499170M },
                new TerritoryBound { BoundaryID = 2600, TerritoryID = 1, GeoLat = 40.585920M, GeoLong = -75.499430M },
                new TerritoryBound { BoundaryID = 2601, TerritoryID = 1, GeoLat = 40.585780M, GeoLong = -75.499610M },
                new TerritoryBound { BoundaryID = 2602, TerritoryID = 1, GeoLat = 40.585650M, GeoLong = -75.499780M },
                new TerritoryBound { BoundaryID = 2603, TerritoryID = 1, GeoLat = 40.585370M, GeoLong = -75.500110M },
                new TerritoryBound { BoundaryID = 2604, TerritoryID = 1, GeoLat = 40.585110M, GeoLong = -75.500400M },
                new TerritoryBound { BoundaryID = 2605, TerritoryID = 1, GeoLat = 40.584870M, GeoLong = -75.500660M },
                new TerritoryBound { BoundaryID = 2606, TerritoryID = 1, GeoLat = 40.584750M, GeoLong = -75.500820M },
                new TerritoryBound { BoundaryID = 2607, TerritoryID = 1, GeoLat = 40.584660M, GeoLong = -75.500970M },
                new TerritoryBound { BoundaryID = 2608, TerritoryID = 1, GeoLat = 40.584580M, GeoLong = -75.501080M },
                new TerritoryBound { BoundaryID = 2609, TerritoryID = 1, GeoLat = 40.584530M, GeoLong = -75.501210M },
                new TerritoryBound { BoundaryID = 2610, TerritoryID = 1, GeoLat = 40.584480M, GeoLong = -75.501330M },
                new TerritoryBound { BoundaryID = 2611, TerritoryID = 1, GeoLat = 40.584430M, GeoLong = -75.501470M },
                new TerritoryBound { BoundaryID = 2612, TerritoryID = 1, GeoLat = 40.584400M, GeoLong = -75.501590M },
                new TerritoryBound { BoundaryID = 2613, TerritoryID = 1, GeoLat = 40.584370M, GeoLong = -75.501700M },
                new TerritoryBound { BoundaryID = 2614, TerritoryID = 1, GeoLat = 40.584340M, GeoLong = -75.501820M },
                new TerritoryBound { BoundaryID = 2615, TerritoryID = 1, GeoLat = 40.584320M, GeoLong = -75.501950M },
                new TerritoryBound { BoundaryID = 2616, TerritoryID = 1, GeoLat = 40.584300M, GeoLong = -75.502240M },
                new TerritoryBound { BoundaryID = 2617, TerritoryID = 1, GeoLat = 40.584280M, GeoLong = -75.502550M },
                new TerritoryBound { BoundaryID = 2618, TerritoryID = 1, GeoLat = 40.584240M, GeoLong = -75.503010M }
            });

        // modelBuilder.Entity<Door>().HasData(new Door[] {
        //         new Door {
        //             Id = 1,
        //             TerritoryID = 1
        //         }
        //     });

        return modelBuilder;

    }
}
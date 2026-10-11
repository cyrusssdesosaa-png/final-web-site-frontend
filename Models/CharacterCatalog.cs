namespace WallyWombatsPublic_MVC.Models;

public class CharacterProfile
{
    public string Slug { get; set; } = "";
    public string Name { get; set; } = "";
    public string ShortName { get; set; } = "";
    public string Headline { get; set; } = "";
    public string Greeting { get; set; } = "";
    public string Intro { get; set; } = "";
    public string Story { get; set; } = "";
    public string Image { get; set; } = "";
    public string Tagline { get; set; } = "";
    public Dictionary<string, string> Facts { get; set; } = new();
    public List<string> Loves { get; set; } = new();
    public string DidYouKnow { get; set; } = "";
}

public static class CharacterCatalog
{
    public static IReadOnlyList<CharacterProfile> All { get; } = new[]
    {
        NeyNey(),
        Bunski(),
        Wally(),
        DonDon(),
        LenLen()
    };

    public static CharacterProfile? Find(string? slug) =>
        All.FirstOrDefault(c => string.Equals(c.Slug, slug, StringComparison.OrdinalIgnoreCase));

    private static CharacterProfile Wally() => new()
    {
        Slug = "wally",
        Name = "Wally Wombat",
        ShortName = "Wally",
        Tagline = "The friendly little wombat with a big heart for adventure",
        Headline = "G'day, mate! Meet Wally!",
        Greeting = "All the way from Australia",
        Intro = "Wally Wombat is a cheerful little explorer who loves making friends, discovering new things, and turning everyday moments into exciting adventures. Whether he's learning a new game, exploring a new place, or helping a friend feel brave, Wally believes that the best adventures are the ones we share together.",
        Story = "Wally's adventure began in beautiful Australia, where he grew up safe and snug in his mother's pouch. As a wombat, he's part of a special group of animals called marsupials! But Wally's curiosity was too big to stay in one place. His adventures eventually brought him to America, where he discovered new places, exciting experiences, and wonderful friends. Now living in Hot Springs, Arkansas, Wally continues exploring the world around him, learning important lessons about friendship, kindness, movement, and trying new things.",
        Image = "~/img/theme/characters/stand-wally.png",
        Facts = new Dictionary<string, string>
        {
            ["From"] = "Australia",
            ["New home"] = "Hot Springs, Arkansas, USA",
            ["Personality"] = "Friendly, curious, playful, adventurous, and kind",
            ["Superpower"] = "Making everyone feel welcome and ready to play"
        },
        Loves = new List<string>
        {
            "Exploring new places and meeting new friends",
            "Running, jumping, dancing, and playing games",
            "Learning about animals and the world",
            "Discovering new sports with his friends",
            "Turning little moments into big adventures"
        },
        DidYouKnow = "Wally is a wombat, a real animal from Australia! Baby wombats are called joeys, and they grow inside their mother's pouch before they're ready to explore the world."
    };

    private static CharacterProfile DonDon() => new()
    {
        Slug = "don-don",
        Name = "Don Don",
        ShortName = "Don Don",
        Tagline = "The sporty best friend who's always ready to play",
        Headline = "Ready, set, let's go!",
        Greeting = "Wally's energetic best buddy",
        Intro = "Meet Don Don, Wally's energetic, adventurous, and super-friendly best buddy! Born and raised in San Antonio, Texas, Don Don loves sports, outdoor adventures, and cheering on his friends. Whether he's kicking a soccer ball, riding his bicycle, or teaching Wally a new game, Don Don knows that playing together is always more fun.",
        Story = "Don Don is 8 years old, and his family comes from Mexico. He's proud of both his Mexican heritage and his Texas hometown! His dad is an architect, and his mom is an accountant. They've taught him to work hard, be responsible, and always help others. Don Don loves sharing his family's traditions with his friends. He even teaches Wally a little Spanish, especially his favorite adventure word: \"Vamos!\" That means \"Let's go!\"",
        Image = "~/img/theme/characters/stand-dondon.png",
        Facts = new Dictionary<string, string>
        {
            ["Hometown"] = "San Antonio, Texas",
            ["Family heritage"] = "Mexican",
            ["Personality"] = "Brave, energetic, honest, friendly, and dependable",
            ["Special talent"] = "Running fast and playing soccer",
            ["Best animal buddy"] = "Moo Moo, his playful dog"
        },
        Loves = new List<string>
        {
            "Playing soccer",
            "Playing cricket with Wally",
            "Riding his bicycle and hiking",
            "Spending time with Moo Moo"
        },
        DidYouKnow = "Don Don is one of the fastest runners in his neighborhood! But winning isn't everything to him. He believes everyone deserves a chance to play."
    };

    private static CharacterProfile LenLen() => new()
    {
        Slug = "len-len",
        Name = "Len-Len",
        ShortName = "Len-Len",
        Tagline = "The cheerful friend who brings music, movement, and smiles",
        Headline = "Turn up the music! Len-Len is here!",
        Greeting = "Happy, confident, and creative",
        Intro = "Meet Len-Len, the happy, confident, and creative friend who loves to sing, dance, and make every day a celebration! With her beautiful singing voice and joyful personality, Len-Len can turn even the quietest afternoon into an exciting dance party.",
        Story = "Len-Len's family comes from Kenya, a beautiful country in Africa. She moved to the United States with her parents and older brother when she was just a baby. Her family loves sharing Kenyan traditions, music, and delicious home-cooked meals. Len-Len enjoys expressing herself through music and dancing. She also loves playing hide-and-seek, where her clever thinking helps her find the best hiding spots. Most importantly, Len-Len believes everyone deserves to be included in the fun.",
        Image = "~/img/theme/characters/stand-lenlen.png",
        Facts = new Dictionary<string, string>
        {
            ["Family heritage"] = "Kenyan",
            ["Home"] = "United States",
            ["Personality"] = "Cheerful, confident, kind, creative, and outgoing",
            ["Special talent"] = "Singing and dancing",
            ["Favorite game"] = "Hide-and-seek"
        },
        Loves = new List<string>
        {
            "Singing her favorite songs",
            "Making up silly tunes",
            "Dancing with friends",
            "Playing hide-and-seek",
            "Celebrating with her family"
        },
        DidYouKnow = "Len-Len can make up a silly song almost anywhere. All she needs is a little imagination and friends who are ready to join in!"
    };

    private static CharacterProfile Bunski() => new()
    {
        Slug = "bunski",
        Name = "Bunski",
        ShortName = "Bunski",
        Tagline = "The sweet little chef with big ideas and an even bigger heart",
        Headline = "What's cooking? It's Bunski!",
        Greeting = "Sweet, thoughtful, and super-smart",
        Intro = "Meet Bunski, Wally's sweet, thoughtful, and super-smart friend who loves cooking, counting, and creating something special. Bunski may be a little shy when meeting someone new, but once she feels comfortable, her wonderful imagination begins to shine!",
        Story = "Bunski recently moved to the United States from the Philippines. Everything feels new and exciting, but sometimes making new friends can feel a little scary. Luckily, Wally and his friends are always there to make her feel welcome! Bunski loves playing chef in her pretend kitchen, where she creates delicious Filipino dishes like lumpia, pancit, and adobo. She's also amazing at math! From counting ingredients to solving puzzles, Bunski knows that numbers can be fun. With every new friendship and adventure, Bunski learns that being yourself is something to celebrate.",
        Image = "~/img/theme/characters/stand-bunski.png",
        Facts = new Dictionary<string, string>
        {
            ["From"] = "Philippines",
            ["New home"] = "United States",
            ["Personality"] = "Sweet, shy, thoughtful, smart, and creative",
            ["Special talent"] = "Math and pretend cooking",
            ["Favorite color"] = "Purple",
            ["Favorite foods"] = "Lumpia, chicken adobo, pancit, halo-halo, and ube ice cream"
        },
        Loves = new List<string>
        {
            "Cooking pretend meals",
            "Solving number puzzles",
            "Building with blocks",
            "Decorating colorful dishes",
            "Sharing Filipino traditions"
        },
        DidYouKnow = "Bunski has a tiny stuffed chick named Pio that she keeps on her kitchen shelf. She also dreams of opening a restaurant where children from around the world can discover new foods!"
    };

    private static CharacterProfile NeyNey() => new()
    {
        Slug = "ney-ney",
        Name = "Ney-Ney",
        ShortName = "Ney-Ney",
        Tagline = "The curious little explorer who believes every place has a story",
        Headline = "Grab your map! Adventure awaits with Ney-Ney!",
        Greeting = "Curious, imaginative, and thoughtful",
        Intro = "Meet Ney-Ney, Wally's curious, imaginative, and thoughtful friend who loves discovering the wonderful world around her. From faraway countries and fascinating castles to exciting stories from long ago, Ney-Ney believes there's always something new to learn!",
        Story = "Ney-Ney was born and raised in sunny Long Beach, California. Her family has roots in different parts of the United States, and her ancestors came from Scotland many years ago. She loves learning about places, people, and cultures from around the world. Give Ney-Ney a map, a globe, or a storybook, and she's ready for a new adventure! She's also wonderfully creative. Ney-Ney enjoys sewing tiny outfits for her dolls and designing clothes inspired by different places and cultures. When Wally and his friends need help planning an adventure, Ney-Ney is often the first person they ask!",
        Image = "~/img/theme/characters/stand-naenae.png",
        Facts = new Dictionary<string, string>
        {
            ["Hometown"] = "Long Beach, California",
            ["Family heritage"] = "Scottish ancestry",
            ["Personality"] = "Curious, patient, thoughtful, kind, and imaginative",
            ["Special talent"] = "Remembering maps, countries, and landmarks",
            ["Favorite places"] = "Museums, libraries, and historical landmarks"
        },
        Loves = new List<string>
        {
            "Reading maps",
            "Listening to stories",
            "Learning about history",
            "Solving puzzles",
            "Visiting museums",
            "Designing doll clothes"
        },
        DidYouKnow = "Ney-Ney can recognize many countries just by their shapes on a map! She dreams of visiting every continent one day."
    };
}

*Recommended Markdown Viewer: [Markdown Editor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2)*

https://zenn.dev/apterygiformes/articles/0e7982e45ea1c6

https://github.com/CommunityToolkit/MVVM-Samples

https://qiita.com/hqf00342/items/40a753edd8e37286f996

https://www.youtube.com/watch?v=vD17OetzGXc


    public interface IWeatherRepository
    {
        WeatherEntity GetLatest(int areaId);
        IReadOnlyList<WeatherEntity> GetData();
        void Save(WeatherEntity weather);
    }

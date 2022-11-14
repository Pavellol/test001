using Telegram.Bot;
using Telegram.Bot.Exceptions;
//using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
Console.OutputEncoding = System.Text.Encoding.UTF8;
//Переменная ТГ бота
var botClient = new TelegramBotClient("5671400176:AAFVG9763O-Tq1YZM_5CEx6P12v3DL72qX0");

using var cts = new CancellationTokenSource();
//Настройки получения обновлений
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }
};
//Функция где мы это компонуем и получаем обновления от Телеграм
botClient.StartReceiving(
    HandleUpdatesAsync,//метод, Обработка обновлений бота
    HandleErrorAsync,//метод обработки ошибок
    receiverOptions,//настройки получения обновлений
    cancellationToken: cts.Token);//токен отмены

var me = await botClient.GetMeAsync();

Console.WriteLine($"Начал работу @{me.Username}");
Console.ReadLine();

cts.Cancel();//отмена токена
//обработка событий
async Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Type == UpdateType.Message && update?.Message?.Text != null)
    {
        await HandleMessage(botClient, update.Message);
        return;
    }

    if (update.Type == UpdateType.CallbackQuery)
    {
        await HandleCallbackQuery(botClient, update.CallbackQuery);
        return;
    }
}

async Task HandleMessage(ITelegramBotClient botClient, Message message)
{
    //if (message.Text == "/start")
    //{
    //    await botClient.SendTextMessageAsync(message.Chat.Id,
    //        "Добро пожаловать.\n" +
    //        "Я РС бот АН СПб.\n" +
    //        "/keyboard |\n" +
    //        "/infotion Информация  s");
    //    return;
    //}

    //if (message.Text == "/start")
    //{
    //    ReplyKeyboardMarkup keyboard = new(new[]
    //    {
    //        new KeyboardButton[] {"Что такое ПРС", "Подключение к рассылке АН СПб"},
    //        new KeyboardButton[] {"Заказ тренингов", "Заказ семинаров" },
    //        new KeyboardButton[] {"Заказать десант"},

    //    })
    //    {
    //        ResizeKeyboard = true
    //    };


    //    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите клавишу:", replyMarkup: keyboard);
    //    return;
    //}


    if (message.Text == "/start")
    {
        InlineKeyboardMarkup keyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Что такое ПРС", "инфорфмацияРС"),
                
            },
           new[]
            {
               InlineKeyboardButton.WithCallbackData("Заказ тренингов", "тренинги"),
               InlineKeyboardButton.WithCallbackData("Заказ семинаров", "семинары"),
               InlineKeyboardButton.WithCallbackData("Заказ десанта", "десант"),
            },
            new[]
            {
               InlineKeyboardButton.WithCallbackData("Подключение к рассылке", "рассылка"),
            },
        });
        await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите кнопку:", replyMarkup: keyboard);
        return;
    }
    //Если команда боту не знакома, то он реплаит это же сообщение:
    await botClient.SendTextMessageAsync(message.Chat.Id, $"You said:\n{message.Text}");
}
async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
{
    if (callbackQuery.Data.StartsWith("инфорфмацияРС"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"Главными целями Подкомитета по Развитию Сообщества являются:\n " +
            $"Оказание помощи новым группам\n" +
            $"Поддержка существующих групп АН в улучшении эффективности служения и несения вести АН\n" +
            $"Содействовать развитию местности в целом"
        );
        return;
    }

    if (callbackQuery.Data.StartsWith("рассылка"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"Перейдите: https://t.me/naspb12"// Спросить у Стёпы про функцию перехода по ссылке
        );
        return;
    }
    
    if (callbackQuery.Data.StartsWith("семинары"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"/1 Список проводимых семинаров:\n" +
            $"/2 Ясность нашей вести\n" +
            $"/3 Шаги АН\n" +
            $"/4 Хищническое поведение в АН\n" +
            $"/5 Фасилитатор\n" +
            $"/6 Традиции АН\n" +
            $"/7 Тёмная сторона в служении\n" +
            $"/8 Структура обслуживания в Анм" +
            $"/9 Стратегическое планированием" +
            $"/10 Спонсорство\n" +
            $"/11 Социальные сети\n" +
            $"/12 Сопереживание, поддержка и любовь в сообществе\n" +
            $"/13 СМИ, технологии и наши духовные принципым" +
            $"/14 Служение ЧРК\n" +
            $"/15 Служение как неотъемлемая часть выздоровления\n" +
            $"/16 Служение в АН\n" +
            $"/17 Семинары для ПГО\n" +
            $"/18 Секретарь группы АН\n" +
            $"/19 Самообеспечение от А до Я\n" +
            $"/20 Самообеспечение в АН (традиция Седьмая)\n" +
            $"/21 Руководящий принцип - дух наших традиций\n" +
            $"/22 Руководство ЛитКомов\n" +
            $"/23 РС- с чего начать?\n" +
            $"/24 Развитие сообщества\n" +
            $"/25 Простые истины в служении\n" +
            $"/26 Про деньги\n" +
            $"/27 Принцип ротации\n" +
            $"/28 Привлечение членов сообщества в служение\n" +
            $"/29 Планирование\n" +
            $"/30 Открыть новую группу\n" +
            $"/31 Новичок в АН\n" +
            $"/32 Нести весть в АН и делать АН привлекательным\n" +
            $"/33 Мотивация служащих\n" +
            $"/34 Лидерство в АН\n" +
            $"/35 Концепции АН\n" +
            $"/36 Комуникация и представительство\n" +
            $"/37 История появления литературы в России\n" +
            $"/38 История денег\n" +
            $"/39 История БТ\n" +
            $"/40 История АН\n" +
            $"Информационная линия\n" +
            $"" +
            $"Имидж АН\n" +
            $"Заместительная терапия и медикаментозное лечение\n" +
            $"Единство в АН\n" +
            $"Духовный кризис\n" +
            $"Добро пожаловать всем (Традиция третья)\n" +
            $"Добро пожаловать в АН\n" +
            $"Выздоравливая в АН\n" +
            $"Ведущий собрания АН\n" +
            $"Вдохновлённые нашей главной целью (Традиция пятая)\n" +
            $"Бог как каждый из нас понимает его\n" +
            $"" +
            $"Атмосфера выздоровления в служении\n" +
            $"12 Шагов АН\n" +
            $"12 простых истин в служении АН\n"

        );
        return;
    }
    
    if (callbackQuery.Data.StartsWith("тренинги"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"tren"
        );
        return;
    }

    if (callbackQuery.Data.StartsWith("десант"))
    {
        await botClient.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"десант"
        );
        return;
    }

    await botClient.SendTextMessageAsync(
        callbackQuery.Message.Chat.Id,
        $"You choose with data: {callbackQuery.Data}"
        );

    static void InformationAboutRsComunity()
    {
        Console.WriteLine
            (
                $"Главными целями Подкомитета по Развитию Сообщества являются:\n\n " +
                $"Оказание помощи новым группам\n" +
                $"Поддержка существующих групп АН в улучшении эффективности служения и несения вести АН\n" +
                $"Содействовать развитию местности в целом"
            );
    }
    return;
}
//Обработка ошибок
Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Ошибка телеграм АПИ:\n{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
        _ => exception.ToString()
    };
    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
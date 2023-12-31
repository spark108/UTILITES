# UTILITES
Небольшие самописные инструменты на C# / Small self-written tools in C#

## Список утилит
|Утилита|Версия|Дата обновления|
|-|-|-|
|[Today](#today)|1.0.1|18.07.2023|

## Today

Утилита позволяет каталогизировать ежедневную работу на папки с соответствующей датой, при этом, если запускать программу, то всегда будет открыватся дириктория текущего дня.

Примечание: Утилита создает структуру дирикторий в том месте, где лежит.

### Аргументы запуска

#### Без аргументов

Открывается дириктория текущего дня.

#### Аргумент `n` - указание дня.

Позволяет указать какой день открыть при запуске программы.

- `-n+1` - открывается дириктория следующих дней от текущего. Можно указать любое прибавление суток.
- `-n-1` - аналогично предыдущему, только для открытия дириктории предыдущих дней.

Например открыть десятый день после текущего:
```
\Today.exe n+10
```

Или открыть вчерашний день:
```
\Today.exe n-1
```

#### `-format` - указывает формат каталогизации. (НЕ РЕАЛИЗОВАННО!)

|Параметр|Описание|
|-|-|
|`\`|Разделитель дириктории.|

Так же могут быть применены все [Параметры замены](#параметры-замены).

Например, создается дириктория `\2023\1.ЯНВАРЬ\1.1`:
```
\Today.exe -format="Y\m.M\d.m"
```

### Шаблон папки дня

Шаблон папки дня позволяет заранее заготовить типовое содержимое для вновь создоваемой папки дня. Например заранее подготовить структуру каталогов или шаблонные файлы.

Шаблон будет копироватся в вновь созданную папку дня.

Для этого рядом с исполняемым файлом необходимо создать папку `template` и поместить в неё все необходимое.

Вы так же можете использовать некоторые заменяемые параметры в указании названий файлов и папок шаблона. Для этого необходимо указать параметр следующим видом `%параметр%`.

Например файл с именем `Сводка на %d%.%m%.%Y%.docx` созданная 18 марта 2023 года будет помещена в вновь созданную папку с именем `Сводка на 18.03.2023.docx`.

Параметры замены указаны в разделе [Параметры замены](#параметры-замены).

### Параметры замены

Данные параметры замены могут быть использованы для подстановки динамических значенией. Например в шаблоне можете поставить дату в названии файла или папки.

|Параметр|Описание|
|-|-|
|`Y`|Год из 4 цифр.|
|`M`|Название месяца в Caps Lock.|
|`m`|Номер месяца без ведущего нуля.|
|`d`|День.|

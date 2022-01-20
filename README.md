# Шаблон отчёта (ТвГТУ)
В этом проекте представлен шаблон отчёта по лабораторной или курсовой работе. Это fork https://github.com/polytechnic-templates/report-template, переделанный под меня. Может, и Вам будет удобнее.

### Сборка локально

Понадобится *nix система с TeX Live и Tectonic.

```
./configure

make
```

## Заполнение шаблона

1. Изменить `config.tex`: имя студента, название предмета и пр. параметры указаны именно там
1. Заполнить `content.tex` - файл, который будет содержать весь текст отчёта, от вступления до заключения.
1. Добавить используемую литературу (если есть) в `refs.bib`. Для удобного поиска источников можно воспользоваться [Google Books](https://books.google.com/). Использованные источники можно указывать с помощью команды `\cite{name_of_ref}`

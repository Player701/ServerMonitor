# Server Monitor
Приложение для мониторинга состояния сервера с помощью системы Zidium (http://zidium.net)

## Что это такое
Server Monitor - это приложение, написанное на .Net Core, которое собирает информацию о текущем состоянии вашего сервера и отправляет её в систему мониторинга Zidium.
Может работать как в режиме консольного приложения на любой совместимой ОС, так и в режиме Windows-службы.
Умеет отслеживать:
- Размер свободной памяти
- Количество свободного места на дисках

## Как настроить
Скачайте готовую сборку (https://github.com/Zidium/ServerMonitor/releases) или соберите из исходников сами, выполнив файл BuildRelease.bat. Релиз будет в папке Release.
Для самостоятельной сборки нужна Visual Studio версии 2017 CE или выше.
Возможно, вам потребуется в BuildRelease.bat изменить путь к файлу msbuild.exe
Разместите релиз в папке на сервере.

В файле Zidium.config в разделе <access> укажите название вашего аккаунта и секретный ключ (посмотреть его можно в личном кабинете).
Если вы хотите также мониторить работу и самого приложения Server Monitor, то создайте в личном кабинете для него компонент и укажите Id этого компонента в разделе <defaultComponent>.

В файле settings.json в параметре ServerId укажите Id компонента, который представляет ваш сервер. Если такого компонента ещё нет, создайте его в личном кабинете.
Укажите в разделе Disk в параметре Disks названия дисков, для которых вы хотите проверять свободное место.

Если вы используете локальный сервис Api (а не облачный сервис Zidium), не забудьте указать его адрес в файле Zidium.config в разделе <access> в атрибуте "url".

## Как запустить в Windows
Для запуска в режиме консольного приложения просто запустите ZidiumServerMonitor.exe
Для запуска в режиме службы зарегистрируйте службу командой ZidiumServerMonitor.exe -install, а саму службу запустите стандартными средствами Windows.

## Как запустить в любой ОС
Для запуска в любой среде, поддерживающей .Net Core, используйте команду dotnet ZidiumServerMonitor.dll

## Что я увижу в итоге
В компоненте сервера появятся метрики свободной памяти и места на выбранных дисках:
http://zidium.net/Content/wiki/usage-exemples/dot-net/server-monitor/server-state.png

Чтобы получать оповещения о нехватке места, настройте для метрик правила.

Если вы заполнили параметр defaultComponent, то в компоненте самого приложения появятся дочерние компоненты задач с проверками:
http://zidium.net/Content/wiki/usage-exemples/dot-net/server-monitor/application-state.png

## Из чего состоит решение
Решение ServerMonitor.sln состоит из 4-х проектов:
- Core - вся логика приложения
- Core.Tests - юнит-тесты логики приложения
- NetCoreConsoleApplication - приложение в формате .Net Core
- WindowsService - приложение в формате Windows-службы

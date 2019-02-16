# DontSpyServer

General information about the project DontSpy can be [found here](https://dontspy.github.io/).

## How to Use

This section describes how to use this server part of the DontSpy client-server project. In order to use DontSpy as an overall project, please deploy also the [DontSpyClient](https://github.com/dontspy/DontSpyClient).

### Installation

Clone the repository, transfer all the files onto a HTTP Web Server, secure the data transfer between client and server with a SSL certificate, secure the directory of the files with a HTTP Basic Authentification and [adjust the configuration](https://github.com/dontspy/DontSpyServer/blob/master/README.md#configuration). Furthermore, create a new MySQL database and [import the SQL scheme](https://github.com/dontspy/DontSpyServer/blob/master/mysql_dump.sql). You are ready to start.

### API

The API is based on the REST paradigm and provides following RESTful endpoints:

Endpoint Scheme: /user/{username}<br />
HTTP Method: GET<br />
Parameter: None<br />
JSON Request: None<br />
JSON Response: <br />
&nbsp;&nbsp;&nbsp; id : String<br />
&nbsp;&nbsp;&nbsp; username : String

Endpoint Scheme: /message/{receivingChannel}<br />
HTTP Method: GET<br />
Parameter: <br />
&nbsp;&nbsp;&nbsp; limit : limits the number messages returned from the database<br />
&nbsp;&nbsp;&nbsp; offset : controls the pagination<br />
JSON Request: None<br />
JSON Response:<br />
&nbsp;&nbsp;&nbsp; id : String<br />
&nbsp;&nbsp;&nbsp; messageHeader : String<br />
&nbsp;&nbsp;&nbsp; receivingChannel : String<br />
&nbsp;&nbsp;&nbsp; timestamp : int<br />
&nbsp;&nbsp;&nbsp; message : String<br />
&nbsp;&nbsp;&nbsp; processingCounter : int

Endpoint Scheme: /message/processed/{id}<br />
HTTP Method: GET<br />
Parameter: None<br />
JSON Request: None<br />
JSON Response: None<br />

Endpoint Scheme: /message/{id}<br />
HTTP Method: DELETE<br />
Parameter: None<br />
JSON Request: None<br />
JSON Response: None<br />

Endpoint Scheme: /message/new<br />
HTTP Method: POST<br />
Parameter: None<br />
JSON Request:<br />
&nbsp;&nbsp;&nbsp; id : String<br />
&nbsp;&nbsp;&nbsp; messageHeader : String<br />
&nbsp;&nbsp;&nbsp; receivingChannel : String<br />
&nbsp;&nbsp;&nbsp; timestamp : int<br />
&nbsp;&nbsp;&nbsp; message : String<br />
&nbsp;&nbsp;&nbsp; processingCounter : int<br />
JSON Response: None<br />

Endpoint Scheme: /user/new<br />
HTTP Method: POST<br />
Parameter: None<br />
JSON Request:<br />
&nbsp;&nbsp;&nbsp; id : String<br />
&nbsp;&nbsp;&nbsp; username : String<br />
JSON Response: None

### Configuration

Regulation on the access control of the API can be [found here](https://github.com/dontspy/DontSpyServer/blob/master/src/middleware.php#L27). Display configuration concerning errors can be [found here](https://github.com/dontspy/DontSpyServer/blob/master/src/settings.php#L4). Furthermore, the settings of the Logging (Monolog Logger) can be [found here](https://github.com/dontspy/DontSpyServer/blob/master/src/settings.php#L12). Database setting can be [found here](https://github.com/dontspy/DontSpyServer/blob/master/src/settings.php#L19).

## Built with

More information about the third-party dependencies can be found at Section 3.1 in the [documentation of DontSpy](https://github.com/dontspy/dontspy.github.io/blob/master/docs/documentationGerman.pdf) (German Language).

## Contributers

- [Mai Saito](https://github.com/dontspy/DontSpyServer/graphs/contributors)
- [Lukas Ruf](https://github.com/dontspy/DontSpyServer/graphs/contributors)
- [Tobias Straub](https://github.com/dontspy/DontSpyServer/graphs/contributors)
- Helmut Ruf

## License

The License can be [found here](https://github.com/dontspy/DontSpyServer/blob/master/LICENSE).

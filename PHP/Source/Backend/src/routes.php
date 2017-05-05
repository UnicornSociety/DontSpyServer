<?php
// Routes
$app->get('/user/{email}', function($request, $response){

});

$app->get('/message/{id}', function($request, $response){

});

$app->post('/message/new', function($request, $response){
  "timestamp": "",
  "sender": "",
  "receiver":"",
  "message":"",
  "keyNumber":""

});

$app->post('/message/new', function ($request, $response) {
    $data = $request->getParsedBody();
    $message_data = [];
    $message_data['timestamp'] = $data['timestamp'];
    $message_data['sender'] = filter_var($data['sender'], FILTER_SANITIZE_STRING);
    $message_data['receiver'] = filter_var($data['receiver'], FILTER_SANITIZE_STRING);
    $message_data['message'] = filter_var($data['message'], FILTER_SANITIZE_STRING);
    $message_data['keyNumber'] = filter_var($data['keyNumber'], FILTER_SANITIZE_STRING);
    $message_data['UserId'] = filter_var($data['userId'], FILTER_SANITIZE_STRING);
    $message = new UserEntity($message_data);
    $mapper = new UserMapper($this->db);
    $mapper->save($message);
    //$response = $response->withRedirect("/senvis/api/patient/" . $vitalSign_data['patientId'] . "/vitalsign");
    return $response;
});

$app->get('/user', function ($request, $response) {

  });

$app->get('/message/{id}', function ($request, $response) {

    });



//Original

$app->get('/user/{id}', function ($request, $response, $args) {
    $patient_id = (int)$args['id'];
    $mapper = new PatientMapper($this->db);
    $patient = $mapper->getPatientById($patient_id);
    return $response->withJson($patient);
});

$app->get('/message/{id}', function ($request, $response, $args) {
    $patient_id = (int)$args['id'];
    $mapper = new PatientMapper($this->db);
    $patient = $mapper->getPatientById($patient_id);
    return $response->withJson($patient);
});

$app->get('/patient', function ($request, $response) {
    $this->logger->info("Patients list");
    $mapper = new PatientMapper($this->db);
    $patients = $mapper->getPatients();
    return $response->withJson($patients);
});

$app->get('/patient/{id}', function ($request, $response, $args) {
    $patient_id = (int)$args['id'];
    $mapper = new PatientMapper($this->db);
    $patient = $mapper->getPatientById($patient_id);
    return $response->withJson($patient);
});

$app->get('/patient/{id}/vitalsign', function ($request, $response, $args) {
    $patient_id = (int)$args['id'];
    $mapper = new VitalSignMapper($this->db);
    $vitalSign = $mapper->getVitalSignByPatient($patient_id, $request->getQueryParams());
    return $response->withJson($vitalSign);
});

$app->post('/vitalsign/new', function ($request, $response) {
    $data = $request->getParsedBody();
    $vitalSign_data = [];
    $vitalSign_data['timestamp'] = $data['timestamp'];
    $vitalSign_data['amplitude'] = filter_var($data['amplitude'], FILTER_SANITIZE_STRING);
    $vitalSign_data['patientId'] = filter_var($data['patientId'], FILTER_SANITIZE_STRING);
    $vitalSign = new VitalSignEntity($vitalSign_data);
    $mapper = new VitalSignMapper($this->db);
    $mapper->save($vitalSign);
    //$response = $response->withRedirect("/senvis/api/patient/" . $vitalSign_data['patientId'] . "/vitalsign");
    return $response;
});

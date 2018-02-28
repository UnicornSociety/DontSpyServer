<?php
// Routes
$app->get('/user/{username}', function ($request, $response, $args) {
      $user_username = (string)$args['username'];
      $mapper = new UserMapper($this->db);
      $user = $mapper->getUserByUsername($user_username);
      return $response->withJson($user);
  });

  $app->get('/message/{receivingChannel}', function ($request, $response, $args) {
      $receiver = (string)$args['receivingChannel'];
      $mapper = new MessageMapper($this->db);
      $message = $mapper->getMessageByReceiver($receiver, $request->getQueryParams());
      return $response->withJson($message);
  });

  $app->get('/message/processed/{id}', function ($request, $response, $args) {
      $id = (string)$args['id'];
      $mapper = new MessageMapper($this->db);
      $mapper->incrementProcessingCounter($id);
      return $response;
  });

  $app->delete('/message/{id}', function ($request, $response, $args) {
      $id = (string)$args['id'];
      $mapper = new MessageMapper($this->db);
      $mapper->delete($id);
      return $response;
  });

$app->post('/message/new', function ($request, $response) {
    $data = $request->getParsedBody();
    $message_data = [];
    $message_data['id'] = filter_var($data['id'], FILTER_SANITIZE_STRING);
    $message_data['messageHeader'] = filter_var($data['messageHeader'], FILTER_SANITIZE_STRING);
    $message_data['receivingChannel'] = filter_var($data['receivingChannel'], FILTER_SANITIZE_STRING);
    $message_data['timestamp'] = $data['timestamp'];
    $message_data['message'] = filter_var($data['message'], FILTER_SANITIZE_STRING);
    $message_data['processingCounter'] = $data['processingCounter'];
    $message = new MessageEntity($message_data);
    $mapper = new MessageMapper($this->db);
    $mapper->save($message);
    //$response = $response->withRedirect("/senvis/api/patient/" . $vitalSign_data['patientId'] . "/vitalsign");
    return $response;
});

$app->post('/user/new', function ($request, $response) {
    $data = $request->getParsedBody();
    $user_data = [];
    $user_data['id'] = filter_var($data['id'], FILTER_SANITIZE_STRING);
    $user_data['username'] = filter_var($data['username'], FILTER_SANITIZE_STRING);
    $user = new UserEntity($user_data);
    $mapper = new UserMapper($this->db);
    $mapper->save($user);
    //$response = $response->withRedirect("/senvis/api/patient/" . $vitalSign_data['patientId'] . "/vitalsign");
    return $response;
});





//Original

/*    $patient_id = (int)$args['id'];
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
*/

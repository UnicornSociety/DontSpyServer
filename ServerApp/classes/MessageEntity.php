<?php

class MessageEntity implements JsonSerializable
{
    protected $id;
    protected $messageHeader;
    protected $receivingChannel;
    protected $timestamp;
    protected $message;
    protected $processingCounter;

    public function __construct(array $data)
    {
        $this->id = $data['id'];
        $this->messageHeader = $data['messageHeader'];
        $this->receivingChannel = $data['receivingChannel'];
        $this->timestamp = $data['timestamp'];
        $this->message = $data['message'];
        $this->processingCounter = $data['processingCounter'];
    }

// saving data from post message routes

    public function getId()
    {
        return $this->id;
    }
    public function getMessageHeader()
    {
        return $this->messageHeader;
    }
    public function getReceivingChannel()
    {
        return $this->receivingChannel;
    }
    public function getTimestamp()
    {
        return $this->timestamp;
    }
    public function getMessage()
    {
        return $this->message;
    }
    public function getProcessingCounter()
    {
        return $this->processingCounter;
    }
    public function jsonSerialize()
    {
        return [
            'id' => $this->getId(),
            'messageHeader' => $this->getMessageHeader(),
            'receivingChannel' => $this->getReceivingChannel(),
            'timestamp' => $this->getTimestamp(),
            'message' => $this->getMessage(),
            'processingCounter' => $this->getProcessingCounter(),
        ];
    }

}
